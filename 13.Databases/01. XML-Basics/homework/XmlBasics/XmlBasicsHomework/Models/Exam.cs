namespace XmlBasicsHomework.Models
{
    public class Exam
    {
        public Exam()
        {

        }
        public Exam(string name, string turor, int score)
        {
            this.Name = name;
            this.Tutor = turor;
            this.Score = score;
        }

        public string Name { get; set; }

        public string Tutor { get; set; }

        public int Score { get; set; }
    }
}
