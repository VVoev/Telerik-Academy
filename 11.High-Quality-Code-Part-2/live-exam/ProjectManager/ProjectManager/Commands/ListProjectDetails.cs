using Bytes2you.Validation;
using ProjectManager.Contracts;
using ProjectManager.Data;

using System;
using System.Collections.Generic;
using System.Linq;

using ProjectManager.Common.Exceptions;

namespace ProjectManager.Commands
{
    public class ListProjectDetails : ICommand
    {
        private Database db;

        public ListProjectDetails(Database db)
        {
            Guard.WhenArgument(db, "ListProjectDetails Database").IsNull().Throw();
            this.db = db;
        }

        public string Execute(List<string> parameters)
        {          
            if (parameters.Count == 0)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            var projectDetails = this.db.Projects.First(x => x.Id == int.Parse(parameters[0]));
            return string.Join(Environment.NewLine, projectDetails);
        }
    }
}
