namespace StudentApplication.Models
{
    public class Mark
    {
      
        private float currentMark;
        private Subject subject;

        public float CurrentMark
        {
            get
            {
                return this.currentMark;
            }
            private set
            {
                this.currentMark = value;
            }
        }

        public Subject Subject
        {
            get
            {
                return this.subject;
            }
            private set
            {
                this.subject = value;
            }
        }

        public Mark(Subject subject, float value)
        {
            this.Subject = subject;
            this.CurrentMark = value;
        }
    }
}
