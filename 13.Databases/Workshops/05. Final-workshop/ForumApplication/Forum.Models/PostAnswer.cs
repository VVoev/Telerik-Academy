using System;

namespace Forum.Models
{
    public class PostAnswer
    {
        public PostAnswer()
        {
            this.AnsweredOn = DateTime.Now;
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime AnsweredOn { get; private set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}