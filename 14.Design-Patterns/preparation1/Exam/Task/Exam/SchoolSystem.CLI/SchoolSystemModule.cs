using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using SchoolSystem.Cli.Configuration;
using SchoolSystem.Cli.Interceptor;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Providers;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;
using Ninject.Extensions.Interception.Infrastructure.Language;
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

            //Registering first three dependacies for engine to start
            Kernel.Bind<IReader>().To<ConsoleReaderProvider>().InSingletonScope();
            Kernel.Bind<IWriter>().To<ConsoleWriterProvider>().InSingletonScope();
            Kernel.Bind<IParser>().To<CommandParserProvider>().InSingletonScope();

            //Registering factories in order to work with command and studentfactory,teacherFactory and markFactory
            var commandFactoryBinding = Kernel.Bind<ICommandFactory>().ToFactory().InSingletonScope();
            var studentFactoryBinding = Kernel.Bind<IStudentFactory>().ToFactory().InSingletonScope();
            var markFactoryBinding = Kernel.Bind<IMarkFactory>().ToFactory().InSingletonScope();
            Kernel.Bind<ITeacherFactory>().ToFactory().InSingletonScope();


            //Registering AllComands
            Kernel.Bind(typeof(IAddStudent), typeof(IAddTeacher), typeof(IRemoveStudent), typeof(IRemoveTeacher), typeof(IGetStudent), typeof(IGetTeacher), typeof(IGetTeacherAndStudent))
               .To<School>()
               .InSingletonScope();

            //Important paramers should be 1 to 1 example firstName = firstName
            Bind<ICommand>().ToMethod(context =>
            {
                Type commandType = (Type)context.Parameters.Single().GetValue(context, null);
                return (ICommand)context.Kernel.Get(commandType);
            }).NamedLikeFactoryMethod((ICommandFactory commandFactory) => commandFactory.GetCommand(null));

            //for Interception Nuget => Ninject.Extensions.Interception.DynamicProxy

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            if (configurationProvider.IsTestEnvironment)
            {
                commandFactoryBinding.Intercept().With<PerformanceWatch>();
                studentFactoryBinding.Intercept().With<PerformanceWatch>();
                markFactoryBinding.Intercept().With<PerformanceWatch>();
            }
        }
    }
}