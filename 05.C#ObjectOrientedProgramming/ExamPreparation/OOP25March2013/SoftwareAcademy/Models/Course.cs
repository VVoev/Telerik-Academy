namespace SoftwareAcademy.Models
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Course : ICourse
    {
        private string name;
        private ITeacher teacher;
        private ICollection<string> topics;

        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("You must enter course name!");
                }
                this.name = value;
            }
        }

        public ITeacher Teacher
        {
            get
            {
                return this.teacher;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("You must enter teacher!");
                }
                this.teacher = value;
            }
        }

        public ICollection<string> Topics
        {
            get
            {
                return new List<string>();
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.topics = value;
            }
        }

        public void AddTopic(string topic)
        {
            this.Topics.Add(topic);
        }

        public override string ToString()
        {
            //(course type): Name=(course name); Teacher=(teacher name); Topics=[(course topics – comma separated)]; Lab=(lab name – when applicable); Town=(town name – when applicable);
            var sb = new StringBuilder();
            sb.Append(string.Format("Name={0}", this.Name));
            if (this.Teacher.Name != null)
            {
                sb.Append(string.Format("; Teacher={0}", this.Teacher.Name));
            }
            if (this.Topics.Count > 0)
            {
                sb.Append(string.Format("; Topics={0}", string.Join(", ", this.Topics)));
            }
            sb.AppendLine();
            return sb.ToString().TrimEnd();
        }
    }
}
