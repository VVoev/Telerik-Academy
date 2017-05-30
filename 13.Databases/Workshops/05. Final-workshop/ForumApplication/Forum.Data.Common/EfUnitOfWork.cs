using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Common
{
    public class EfUnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext context;

        public EfUnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
