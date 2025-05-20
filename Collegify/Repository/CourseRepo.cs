using Collegify.Models;

namespace Collegify.Repository
{
	public class CourseRepo : Repo<Course>, ICourseRepo
	{
		AppDbContext context;
        public CourseRepo(AppDbContext context) : base(context)
        {
			this.context = context;
        }

        public void Save()
		{
			context.SaveChanges();
		}

		public void Update(Course course)
		{
			context.Courses.Update(course);
		}
	}
}
