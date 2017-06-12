using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using Ninject.Parameters;
using SchoolSystem.Cli.Configuration;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Providers;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using static SchoolSystem.Framework.Core.Commands.CreateStudentCommand;
using static SchoolSystem.Framework.Core.Commands.CreateTeacherCommand;

namespace SchoolSystem.Cli
{
    public class PerformanceWatch : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            invocation.Proceed();
            watch.Stop();
            Console.WriteLine($"Total execution time {watch.Elapsed.Milliseconds}");
        }
    }
    public class SchoolSystemModule : NinjectModule
    {
        public override void Load()
        {
            //Registering
            Kernel.Bind<IConfigurationProvider>().To<ConfigurationProvider>();

            Kernel.Bind<IReader>().To<ConsoleReaderProvider>();
            Kernel.Bind<IWriter>().To<ConsoleWriterProvider>();
            Kernel.Bind<IParser>().To<CommandParserProvider>();

            Kernel.Bind<IStudent>().To<Student>();
            Kernel.Bind<ITeacher>().To<Teacher>();
            Kernel.Bind<IMark>().To<Mark>();


            Kernel.Bind<IStudentFactory>().ToFactory();
            Kernel.Bind<ITeacherFactory>().ToFactory();
            Kernel.Bind<IMarkFactory>().ToFactory();

            Kernel.Bind(typeof(IAddStudent), typeof(IRemoveStudent), typeof(IGetStudent), typeof(IAddTeacher),
                        typeof(IRemoveTeacher), typeof(IGetTeacher), typeof(IGetTeacherAndStudent))
                        .To<School>().InSingletonScope();


            Kernel.Bind<Engine>().ToSelf();                     //Kernel.Bind<Engine>().To<Engine>();

            Kernel.Bind<CreateStudentCommand>().ToSelf().InSingletonScope();
            Kernel.Bind<CreateTeacherCommand>().ToSelf().InSingletonScope();


            Kernel.Bind<CreateStudentCommand>().ToSelf().InSingletonScope();
            Kernel.Bind<CreateTeacherCommand>().ToSelf().InSingletonScope(); 
            Kernel.Bind<RemoveTeacherCommand>().ToSelf().InSingletonScope(); 
            Kernel.Bind<RemoveStudentCommand>().ToSelf().InSingletonScope(); 
            Kernel.Bind<StudentListMarksCommand>().ToSelf().InSingletonScope();
            Kernel.Bind<TeacherAddMarkCommand>().ToSelf().InSingletonScope();


            //Kernel.Bind<ICommandFactory>().To<CommandFactory>();  
            //Kernel will make dynamic class which will implement the interface ICommandFactory
            Kernel.Bind<ICommandFactory>().ToFactory();

            Kernel.Bind<ICommand>().ToMethod(context =>
            {
                IParameter typeParameters = context.Parameters.Single();
                Type type = (Type)typeParameters.GetValue(context, null);

                return (ICommand)context.Kernel.Get(type);
            }).NamedLikeFactoryMethod((ICommandFactory commandfactory)=> commandfactory.GetCommand(null));





            //Geting
            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            Kernel.Bind<IStudentFactory>().ToFactory();




            var commandFactoryBinding = Kernel.Bind<ICommandFactory>().ToFactory();
            var teacherFactoryBinding = Kernel.Bind<ITeacherFactory>().ToFactory();
            var markFactoryBinding = Kernel.Bind<IMarkFactory>().ToFactory();


            if (configurationProvider.IsTestEnvironment)
            {
                commandFactoryBinding.Intercept().With<PerformanceWatch>();
                teacherFactoryBinding.Intercept().With<PerformanceWatch>();
                markFactoryBinding.Intercept().With<PerformanceWatch>();
            }
        }
    }

}