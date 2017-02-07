using System;
using System.Collections.Generic;
using Tasker.Core.Contracts;
using Tasker.Core.Models;

namespace Tasker.Tests.Core.TaskManager
{
    public class TaskManager
    {
        private IIdProvider idProvider;
        private ILogger logger;
        private ICollection<ITask> tasks;

        public TaskManager(IIdProvider idProvider, ILogger logger)
        {
            if(idProvider == null)
            {
                throw new ArgumentException();
            }
            if (logger == null)
            {
                throw new ArgumentException();
            }
            this.idProvider = idProvider;
            this.logger = logger;
            this.tasks = new List<ITask>();
        }

        public void Add(ITask Task)
        {
            if(Task== null)
            {
                throw new ArgumentNullException("Task cannot be null)");
            }
            this.tasks.Add(Task);
        }
    }
}
