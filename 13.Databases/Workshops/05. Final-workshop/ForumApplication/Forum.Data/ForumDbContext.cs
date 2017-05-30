using Forum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data
{
    public class ForumDbContext : DbContext
    {
        public ForumDbContext()
            :base("ForumDb")
        {
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories{ get; set; }

        public DbSet<PostAnswer> Answers { get; set; }

        public DbSet<Tag> Tags { get; set; }

    }
}
