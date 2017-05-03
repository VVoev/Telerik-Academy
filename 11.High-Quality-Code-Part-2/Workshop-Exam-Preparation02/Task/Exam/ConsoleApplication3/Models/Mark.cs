namespace SchoolSystem.Models
{
    using System;
    using Contracts;
    using SchoolSystem.Enums;

    public class Mark : IMark
    {
        private float currentMark;
        private Subject subject;

        public Mark(Subject subject, float currentMark)
        {
            this.Subject = subject;
            this.CurrentMark = currentMark;
        }

        public float CurrentMark
        {
            get
            {
                return this.currentMark;
            }

            set
            {
                //todo validations for mark
                this.currentMark = value;
            }
        }

        public Subject Subject
        {
            get
            {
                return this.subject;
            }

            set
            {
                //todo validations for subject
                this.subject = value;
            }
        }
    }
}
