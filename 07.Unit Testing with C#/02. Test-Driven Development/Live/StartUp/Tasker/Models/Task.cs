using System;

namespace Tasker.Models
{
    public class Task
    {
        private int id;

        private string description;

        public Task()
        {

        }

        public Task(string description)
        {
            this.Description = description;
        }

        public int ID
        {
            get { return this.id; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("ID cannot be less than 0");
                }
                this.id = value;
            }
            
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Description cannot be null or emptry");
                }
                this.description = value;
            }
        }
    }
}
