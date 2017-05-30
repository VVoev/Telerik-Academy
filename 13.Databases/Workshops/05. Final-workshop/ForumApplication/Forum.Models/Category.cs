using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Category
    {
        private ICollection<Post> posts;

        public Category()
        {
            this.posts = new HashSet<Post>();
        }

        public int Id { get; set; }

        [MinLength(5, ErrorMessage = "The length must be at least 5 letters long!")]
        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }

        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }
    }
}
