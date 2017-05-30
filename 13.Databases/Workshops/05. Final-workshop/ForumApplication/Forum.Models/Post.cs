using System;
using System.Collections.Generic;

namespace Forum.Models
{
    public class Post
    {
        private ICollection<PostAnswer> answers;
        private ICollection<Tag> tags;

        public Post()
        {
            this.CreatedOn = DateTime.Now;
            this.answers = new HashSet<PostAnswer>();
            this.tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public PostType PostType { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category{ get; set; }

        public virtual ICollection<PostAnswer> Answers
        {
            get { return this.answers; }
            set { this.answers = value; }
        }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
    }
}