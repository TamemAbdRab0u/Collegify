using Collegify.Models;

namespace Collegify.Repository
{
    public interface IGradeRepo : IRepo<Grade>
    {
        public void Update(Grade grade);
        public void Save();
    }
}
