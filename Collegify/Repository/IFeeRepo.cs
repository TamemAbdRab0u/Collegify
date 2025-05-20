using Collegify.Models;

namespace Collegify.Repository
{
    public interface IFeeRepo : IRepo<Fee>
    {
        public void Update(Fee fee);
        public void Save();
    }
}
