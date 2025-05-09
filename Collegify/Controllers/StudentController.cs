using Collegify.Models;
using Collegify.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Collegify.Controllers
{
	public class StudentController : Controller
	{
		IStudentRepo StdRepo;
		AppDbContext context;
        public StudentController(IStudentRepo StdRepo, AppDbContext context)
        {
            this.StdRepo = StdRepo;
			this.context = context;
        }

        public IActionResult Index()
		{
			List<Student> stds = context.Students.Include(x => x.Department).ToList(); 
			return View(stds);
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(Student std)
		{
			StdRepo.Add(std);
			StdRepo.Save();
			TempData["success"] = "Student Added Successfully";
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int Id)
		{
			Student std = StdRepo.GetById(x => x.Id == Id);
			return View(std);
		}

		[HttpPost]
		public IActionResult Edit(Student std)
		{
			StdRepo.Update(std);
			StdRepo.Save();
			TempData["success"] = "Student Edited Successfully";
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int Id)
		{
			Student std = StdRepo.GetById(x => x.Id == Id);
			return View(std);
		}

		public IActionResult SaveDelete(int Id)
		{
			Student std = StdRepo.GetById(x => x.Id == Id);
			StdRepo.Remove(std);
			StdRepo.Save();
			TempData["success"] = "Student Removed Successfully";
			return RedirectToAction("Index");
		}
	}
}
