using Collegify.Models;

namespace Collegify.Repository
{
	public interface IStudentRepo
	{
		public void Add(Student std);
		public void Update(Student std);
		public void Delete(int Id);
		public List<Student> GetAll();
		public Student GetById(int Id);
		public void Save();
	}
}
