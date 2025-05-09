using Collegify.Models;

namespace Collegify.Repository
{
	public interface IprofessorRepo
	{
		public void Add(Professor prof);
		public void Update(Professor prof);
		public void Delete(int Id);
		public List<Professor> GetAll();
		public Professor GetById(int Id);
		public void Save();
	}
}
