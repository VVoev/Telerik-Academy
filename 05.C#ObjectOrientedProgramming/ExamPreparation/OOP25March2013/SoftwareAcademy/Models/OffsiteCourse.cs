namespace SoftwareAcademy.Models
{
    using System;
    using System.Text;

    using Contracts;

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string townName;

        public OffsiteCourse(string name, ITeacher teacher, string labName)
            : base(name, teacher)
        {
            this.Town = labName;
        }

        public string Town
        {
            get
            {
                return this.townName;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Must enter town name.");
                }
                this.townName = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(string.Format("{0}: ", this.GetType().Name));
            sb.Append(base.ToString());
            sb.AppendLine(string.Format(" Town={0}", this.Town));
            return sb.ToString().TrimEnd();
        }
    }
}
