using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Common
{
    public class EfGenericRepository<T> : IRepository<T> where T: class
    {

        public EfGenericRepository(DbContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected DbContext Context { get; set; }

        protected DbSet<T> DbSet { get; set; }


        public IEnumerable<T> GetAll()
        {
            return this.DbSet.ToList();
        }

        // This one is used for Repository pattern with in-memory collections
        public IEnumerable<T1> GetAll<T1>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> selectExpression)
        {
            IQueryable<T> result = this.DbSet;

            if (filterExpression != null)
            {
                result = result.Where(filterExpression);
            }
            if (selectExpression != null)
            {
                return result.Select(selectExpression).ToList();
            }
            else
            {
                return result.OfType<T1>().ToList();
            }
        }
 
        // For queryable collections
        //public IQueryable<T> GetAll { get; }


        public void Add(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Added;
        }

        public void Delete(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public void Update(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
