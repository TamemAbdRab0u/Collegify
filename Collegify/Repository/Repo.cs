using Collegify.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Collegify.Repository
{
    public class Repo<T> : IRepo<T> where T : class
    {
        AppDbContext context;
        DbSet<T> dbSet;
        public Repo(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();

            // context.category = dbset
        }

        public void Add(T obj)
        {
            dbSet.Add(obj);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetById(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T obj)
        {
            dbSet.Remove(obj);
        }
    }
}
