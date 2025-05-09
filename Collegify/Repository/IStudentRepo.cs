using Collegify.Models;

namespace Collegify.Repository
{
	public interface IStudentRepo : IRepo<Student>
	{
		public void Update(Student std);
		public void Save();
	}
}
