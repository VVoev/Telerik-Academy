namespace Dealership.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Contracts;
    using Common;

    public class Comment : IComment
    {
        private string author;
        private string content;

        public Comment(string content)
        {
            this.Content = content;
        }

        public string Author
        {
            get
            {
                return this.author;
            }
            set
            {
                Validator.ValidateNull(value, "Author can not be null");
                this.author = value;
            }
        }

        public string Content
        {
            get
            {
                return this.content;
            }
            private set
            {
                Validator.ValidateNull(value, Constants.CommentCannotBeNull);
                Validator.ValidateIntRange(value.Length,
                                           Constants.MinCommentLength,
                                           Constants.MaxCommentLength,
                                           string.Format(Constants.StringMustBeBetweenMinAndMax,
                                           "Content",
                                           Constants.MinCommentLength,
                                           Constants.MaxCommentLength));
                this.content = value;

            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("    " + new string('-', 10));
            sb.AppendLine(string.Format("    {0}", this.Content));
            sb.AppendLine("      User: " + this.Author);
            sb.AppendLine("    " + new string('-', 10));
            return sb.ToString().TrimEnd();
        }
    }
}
