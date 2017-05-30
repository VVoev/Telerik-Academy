using Forum.Data.Common;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.ConsoleClient
{
    public class MyDataProvider
    {
        public IRepository<Category> categories;
        public IRepository<Post> posts;
        public Func<IUnitOfWork> unitOfWork;

        public MyDataProvider(
            Func<IUnitOfWork> unitOfWork,
            IRepository<Post> posts,
             IRepository<Category> categories)
        {
            this.categories = categories;
            this.posts = posts;
            this.unitOfWork = unitOfWork;
        }
    }
}
