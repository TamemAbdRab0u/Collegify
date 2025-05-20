using Collegify.Models;

namespace Collegify.Repository
{
	public interface IDepartmentRepo : IRepo<Department>
	{
		public void Update(Department dept);
		public List<Department> Search(string name);
		public void Save();

    }
}
