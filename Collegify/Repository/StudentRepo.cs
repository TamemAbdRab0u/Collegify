using Collegify.Models;

namespace Collegify.Repository
{
	public class StudentRepo : Repo<Student> ,IStudentRepo
	{
		AppDbContext context;
        public StudentRepo(AppDbContext context) : base(context)
        {
            this.context = context;
        }

		public void Update(Student std)
		{
			context.Update(std);
		}

		public void Save()
		{
			context.SaveChanges();
		}
	}
}
