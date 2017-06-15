namespace ProjectManager.Configs
{
    using System.Linq;
    using System.IO;
    using System.Reflection;
    using Ninject;
    using Ninject.Extensions.Factory;
    using Ninject.Modules;
    using ProjectManager.ConsoleClient.Configs;
    using Data;
    using ProjectManager.Framework.Core;
    using ProjectManager.Framework.Core.Commands.Contracts;
    using ProjectManager.Framework.Core.Commands.Creational;
    using ProjectManager.Framework.Core.Commands.Listing;
    using ProjectManager.Framework.Core.Common.Contracts;
    using ProjectManager.Framework.Core.Common.Providers;
    using ProjectManager.Framework.Data;
    using ProjectManager.Framework.Data.Models;
    using Ninject.Extensions.Conventions;

    public class NinjectManagerModule : NinjectModule
    {
        private const string CreateUserCommandName = "createuser";
        private const string CreateTaskCommandName = "createtask";
        private const string CreateProjectCommandName = "createproject";
        private const string ListProjectDetailsCommandName = "listprojectdetails";
        private const string ListProjectsCommandName = "listprojects";

        public override void Load()
        {
            // providers
            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            this.Bind<ILogger>().To<FileLogger>().InSingletonScope().WithConstructorArgument(configurationProvider.LogFilePath);
            this.Bind<IProcessor>().To<CommandProcessor>().InSingletonScope();

            // commands
            this.Bind<ICommand>().To<CreateUserCommand>().InSingletonScope().Named(CreateUserCommandName);
            this.Bind<ICommand>().To<CreateTaskCommand>().InSingletonScope().Named(CreateTaskCommandName);
            this.Bind<ICommand>().To<CreateProjectCommand>().InSingletonScope().Named(CreateProjectCommandName);
            this.Bind<ICommand>().To<ListProjectDetailsCommand>().InSingletonScope().Named(ListProjectDetailsCommandName);
            this.Bind<ICommand>().To<ListProjectsCommand>().InSingletonScope().Named(ListProjectsCommandName);
            this.Bind<IValidator>().To<Validator>().InSingletonScope();
            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            // database
            this.Bind<IDatabase>().To<Database>().InSingletonScope();

            // data
            this.Bind(typeof(IAddProject), typeof(IAddTask), typeof(IAddUser), typeof(IProjectInfo), typeof(IProjectsInfo))
                .To<Database>().InSingletonScope();

            // models
            this.Bind<IUser>().To<User>();

            // factories 
            var userFactoryBinding = this.Bind<IUserFactory>().ToFactory().InSingletonScope();
            var taskFactoryBinding = this.Bind<ITaskFactory>().ToFactory().InSingletonScope();
            var projectFactoryBinding = this.Bind<IProjectFactory>().ToFactory().InSingletonScope();
            var commandFactoryBinding = this.Bind<ICommandsFactory>().ToFactory().InSingletonScope();

            this.Bind<ICommand>()
                .ToMethod(context =>
                {
                    string commandName = (string)context.Parameters.First().GetValue(context, null);
                    commandName = commandName.ToLower();

                    ICommand targetCommand = context.Kernel.Get<ICommand>(commandName);

                    return targetCommand;
                }).NamedLikeFactoryMethod((ICommandsFactory factory) => factory.GetCommandFromString(null));

            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .Where(type => type != typeof(Engine))
                .BindDefaultInterface();
            });
        }
    }
}
