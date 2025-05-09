using Collegify.Models;

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
	}
}
