using Collegify.Models;

namespace Collegify.Repository
{
    public class GradeRepo : Repo<Grade>, IGradeRepo
    {
        AppDbContext context;
        public GradeRepo(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public void Update(Grade grade)
        {
            context.Grades.Update(grade);
        }

        public void Save()
        {
            context.SaveChanges();
        }   
    }
}
