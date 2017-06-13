using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using SchoolSystem.Cli.Configuration;
using SchoolSystem.Framework;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Commands.Factories;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Providers;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SchoolSystem.Cli
{
    public class SchoolSystemModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            Kernel.Bind<IEngine>().To<Engine>().InSingletonScope();

            //Registering the three dependancies that we need for engine to start
            Kernel.Bind<IReader>().To<ConsoleReaderProvider>().InSingletonScope();
            Kernel.Bind<IWriter>().To<ConsoleWriterProvider>().InSingletonScope();
            Kernel.Bind<IParser>().To<CommandParserProvider>().InSingletonScope();

            //Required In Order to start working with Commands
            Bind<ICommand>().ToMethod(context =>
            {
                Type commandType = (Type)context.Parameters.Single().GetValue(context, null);
                return (ICommand)context.Kernel.Get(commandType);
            }).NamedLikeFactoryMethod((ICommandFactory commandFactory) => commandFactory.GetCommand(null));

            //Kernel will make dynamic class which will implement the interface ICommandFactory
            //Nuget Package {{Ninject.Extensions.Factory}}  => Kernel.Bind<ICommandFactory>().To<CommandFactory>();  
            Kernel.Bind<ICommandFactory>().ToFactory();

            Kernel.Bind<CreateStudentCommand>().ToSelf().InSingletonScope();




            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            if (configurationProvider.IsTestEnvironment)
            {
            }

            
        }
    }
}