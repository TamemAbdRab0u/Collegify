using Collegify.Models;
using System.Numerics;

namespace Collegify.Repository
{
	public class DepartmentRepo : Repo<Department> , IDepartmentRepo
	{
		AppDbContext context;
        public DepartmentRepo(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public void Update(Department dept)
        {
            context.Departments.Update(dept);
        }

        public void Save()
		{
			context.SaveChanges();
		}

		public List<Department> Search(string name)
		{
			List<Department> result = context.Departments.Where(x => x.DepartmentName.StartsWith(name)).ToList();
			return result;
		}
	}
}
