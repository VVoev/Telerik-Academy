namespace SchoolSystemCli.Models
{
    using SchoolSystem.CLI.Models.Contracts;
    using SchoolSystemCli.Models.Enums;

    public class Mark : IMark
    {
        public Mark(Subject subject, float mark)
        {
            this.Subject = subject;
            this.MarkExam = mark;
        }

        public float MarkExam { get; }

        public Subject Subject { get; }
    }
}
