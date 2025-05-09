using System.Linq.Expressions;

namespace Collegify.Repository
{
    public interface IRepo<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T GetById(Expression<Func<T, bool>> filter);
        public void Add(T obj);
        public void Remove(T obj);
    }
}
