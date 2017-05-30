using Forum.Data;
using Forum.Data.Common;
using Ninject.Modules;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.ConsoleClient
{
    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            this.Bind<DbContext>().To<ForumDbContext>().InSingletonScope();
            this.Bind(typeof(IRepository<>)).To(typeof(EfGenericRepository<>));
            this.Bind<Func<IUnitOfWork>>().ToMethod(ctx => () => ctx.Kernel.Get<EfUnitOfWork>());
            this.Bind<IUnitOfWork>().To<EfUnitOfWork>();
        }
    }
}
