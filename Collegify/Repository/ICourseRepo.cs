using Collegify.Models;

namespace Collegify.Repository
{
	public interface ICourseRepo : IRepo<Course>
	{
		public void Update(Course course);
		public void Save();
	}
}
