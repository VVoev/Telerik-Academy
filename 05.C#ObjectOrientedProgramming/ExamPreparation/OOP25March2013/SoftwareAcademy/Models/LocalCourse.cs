namespace SoftwareAcademy.Models
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LocalCourse : Course, ILocalCourse
    {
        private string labName;

        public LocalCourse(string name, ITeacher teacher, string labName) 
            : base(name, teacher)
        {
            this.Lab = labName;
        }

        public string Lab
        {
            get
            {
                return this.labName;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Must enter lab name.");
                }
                this.labName = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(string.Format("{0}: ", this.GetType().Name));
            sb.Append(base.ToString());
            sb.AppendLine(string.Format(" Lab={0}", this.Lab));
            return sb.ToString().TrimEnd();
        }
    }
}
