namespace SchoolSystemCli.Models
{
    using SchoolSystem.CLI.Constants;
    using SchoolSystem.CLI.Models.Contracts;
    using SchoolSystemCli.Models.Enums;
    using System;
    public class Mark : IMark
    {
        private float markExam;
        public Mark(Subject subject, float mark)
        {
            this.Subject = subject;
            this.MarkExam = mark;
        }

        public float MarkExam
        {
            get
            {
                return this.markExam;
            }
            set
            {
                if (value < Constant.MarkMinValue || value > Constant.MarkMaxValue)
                {
                    throw new ArgumentException($@"Mark should be between {Constant.MarkMinValue} and {Constant.MarkMaxValue} ");
                }
                this.markExam = value;
            }
        }

        public Subject Subject { get; }
    }
}
