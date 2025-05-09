
using Collegify.Models;

namespace Collegify.Repository
{
	public class StudentRepo : IStudentRepo
	{
		AppDbContext context;
        public StudentRepo(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Student std)
		{
			context.Add(std);
		}
		public void Update(Student std)
		{
			context.Update(std);
		}

		public void Delete(int Id)
		{
			Student std = GetById(Id);
			context.Remove(std);
		}

		public List<Student> GetAll()
		{
			return context.Students.ToList();
		}

		public Student GetById(int Id)
		{
			return context.Students.FirstOrDefault(x => x.Id == Id);
		}

		public void Save()
		{
			context.SaveChanges();
		}

		
	}
}
