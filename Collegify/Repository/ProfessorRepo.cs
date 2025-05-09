using Collegify.Models;

namespace Collegify.Repository
{
	public class ProfessorRepo : IprofessorRepo
	{
		AppDbContext context;
		public ProfessorRepo(AppDbContext context)
		{
			this.context = context;
		}

		public void Add(Professor prof)
		{
			context.Add(prof);
		}
		public void Update(Professor prof)
		{
			context.Update(prof);
		}

		public void Delete(int Id)
		{
			Professor prof = GetById(Id);
			context.Remove(prof);
		}

		public List<Professor> GetAll()
		{
			return context.Professors.ToList();
		}

		public Professor GetById(int Id)
		{
			return context.Professors.FirstOrDefault(x => x.Id == Id);
		}

		public void Save()
		{
			context.SaveChanges();
		}
	}
}
