using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using SchoolSystem.Cli.Configuration;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Providers;
using SchoolSystem.Framework.Models;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SchoolSystem.Cli
{
    public class SchoolSystemModule : NinjectModule
    {
        //Packages that i need
          /*
          <package id = "Castle.Core" version="3.2.0" targetFramework="net452" />
          <package id = "Ninject" version="3.2.0.0" targetFramework="net452" />
          <package id = "Ninject.Extensions.Conventions" version="3.2.0.0" targetFramework="net452" />
          <package id = "Ninject.Extensions.Factory" version="3.2.1.0" targetFramework="net452" />
          <package id = "Ninject.Extensions.Interception" version="3.2.0.0" targetFramework="net452" />
          <package id = "Ninject.Extensions.Interception.DynamicProxy" version="3.2.0.0" targetFramework="net452" />
          */
        public override void Load()
        {
            Kernel.Bind<IEngine>().To<Engine>().InSingletonScope();

            //Register all Dependancies with Engine Use
            Kernel.Bind<IReader>().To<ConsoleReaderProvider>();
            Kernel.Bind<IWriter>().To<ConsoleWriterProvider>();
            Kernel.Bind<IParser>().To<CommandParserProvider>();

            //Bind All IFactory Interfaces to Factories and AlsoBind ICommand
            /*binding for interception */var studentFactoryBinding = Kernel.Bind<IStudentFactory>().ToFactory().InSingletonScope();
            /*binding for interception */var markFactoryBinding = Kernel.Bind<IMarkFactory>().ToFactory().InSingletonScope();
            /*binding for interception */var commandFactoryBinding = Kernel.Bind<ICommandFactory>().ToFactory().InSingletonScope();
            Kernel.Bind<ITeacherFactory>().ToFactory().InSingletonScope();


            Kernel.Bind<ICommand>().ToMethod(context =>
            {
                Type commandType = (Type)context.Parameters.Single().GetValue(context, null);
                return (ICommand)context.Kernel.Get(commandType);
            }).NamedLikeFactoryMethod((ICommandFactory commandFactory) => commandFactory.GetCommand(null));

            //Bind Interfaces to School
            Bind(typeof(IAddStudent), typeof(IAddTeacher), typeof(IRemoveStudent), typeof(IRemoveTeacher), typeof(IGetStudent), typeof(IGetTeacher), typeof(IGetStudentAndTeacher))
                .To<School>()
                .InSingletonScope();

            //If you replace the static with private you should also bind the command where the static was
            Kernel.Bind<CreateStudentCommand>().ToSelf().InSingletonScope();
            Kernel.Bind<CreateTeacherCommand>().ToSelf().InSingletonScope();
            Kernel.Bind<RemoveStudentCommand>().ToSelf().InSingletonScope();
            Kernel.Bind<RemoveTeacherCommand>().ToSelf().InSingletonScope();
            Kernel.Bind<StudentListMarksCommand>().ToSelf().InSingletonScope();
            Kernel.Bind<TeacherAddMarkCommand>().ToSelf().InSingletonScope();

            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            if (configurationProvider.IsTestEnvironment)
            {
                studentFactoryBinding.Intercept().With<PerformanceWatch>();
                markFactoryBinding.Intercept().With<PerformanceWatch>();
                commandFactoryBinding.Intercept().With<PerformanceWatch>();
            }
        }
    }
}