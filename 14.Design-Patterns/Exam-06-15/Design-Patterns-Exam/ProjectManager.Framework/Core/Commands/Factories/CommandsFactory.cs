////using ProjectManager.Framework.Core.Commands.Contracts;
////using ProjectManager.Framework.Core.Common.Exceptions;
////using ProjectManager.Framework.Data;
////using ProjectManager.Framework.Data.Factories;
////using ProjectManager.Framework.Core.Commands.Creational;
////using ProjectManager.Framework.Core.Commands.Listing;
////using ProjectManager.Framework.Core.Common.Providers;
////using ProjectManager.Framework.Core.Common.Contracts;

////namespace ProjectManager.Framework.Core.Commands.Factories
////{
////    public class CommandsFactory : ICommandsFactory
////    {
////        private readonly IDatabase database;
////        private readonly IValidator validator;
////        private readonly IModelsFactory factory;

////        public CommandsFactory(IModelsFactory factory, IValidator validator,IDatabase database)
////        {
////            this.factory = factory;
////            this.validator = validator;
////            this.database = database;
////        }

////        public ICommand GetCommandFromString(string commandName)
////        {
////            switch (commandName.ToLower())
////            {
////                case "createproject":
////                    return this.CreateProjectCommand();
////                case "createuser":
////                    return this.CreateUserCommand();
////                case "createtask":
////                    return this.CreateTaskCommand();
////                case "listprojects":
////                    return this.ListProjectCommand();
////                case "listprojectdetails":
////                    return this.ListProjectDetailsCommand();
////                default:
////                    throw new UserValidationException("No such command!");
////            }
////        }


////        //--Done--
////        public ICommand CreateProjectCommand()
////        {
////            return new CreateProjectCommand(this.factory);
////        }

////        //--Done--
////        public ICommand CreateUserCommand()
////        {
////            return new CreateUserCommand(this.factory);
////        }

////        //--Done--
////        public ICommand CreateTaskCommand()
////        {
////            return new CreateTaskCommand(this.factory);
////        }

////        public ICommand ListProjectCommand()
////        {
////            return new ListProjectsCommand();
////        }

////        public ICommand ListProjectDetailsCommand()
////        {
////            return new ListProjectDetailsCommand();
////        }
////    }
////}
