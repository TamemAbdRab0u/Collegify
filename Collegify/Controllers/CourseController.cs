using Collegify.Models;
using Collegify.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Collegify.Controllers
{
	public class CourseController : Controller
	{
		ICourseRepo CrsRepo;
		IDepartmentRepo DeptRepo;
		AppDbContext context;
        public CourseController(ICourseRepo _CrsRepo, IDepartmentRepo _DeptRepo, AppDbContext _context)
        {
            this.CrsRepo = _CrsRepo;
			this.DeptRepo = _DeptRepo;
			this.context = _context;
        }

        public IActionResult Index()
		{
			List<Course> courses = context.Courses.Include(x => x.Professor).Include(x => x.Department).ToList();
			return View(courses);
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewData["ProfList"] = context.Professors.ToList();
			ViewData["DeptList"] = DeptRepo.GetAll().ToList();
			return View();
		}

		[HttpPost]
		public IActionResult SaveAdd(Course course)
		{
			CrsRepo.Add(course);
			CrsRepo.Save();
			ViewData["ProfList"] = context.Professors.ToList();
			ViewData["DeptList"] = DeptRepo.GetAll().ToList();
			TempData["success"] = "Course Added Successfully";
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int Id)
		{
			Course course = CrsRepo.GetById(x => x.Id == Id);
			ViewData["ProfList"] = context.Professors.ToList();
			ViewData["DeptList"] = DeptRepo.GetAll().ToList();
			return View(course);
		}

		[HttpPost]
		public IActionResult SaveEdit(Course course)
		{
			CrsRepo.Update(course);
			CrsRepo.Save();
			ViewData["ProfList"] = context.Professors.ToList();
			ViewData["DeptList"] = DeptRepo.GetAll().ToList();
			TempData["success"] = "Course Updated Successfully";
			return RedirectToAction("Index");
		}


		public IActionResult Delete(int Id)
		{
			Course course = CrsRepo.GetById(x => x.Id == Id);
			ViewData["ProfList"] = context.Professors.ToList();
			ViewData["DeptList"] = DeptRepo.GetAll().ToList();
			return View(course);
		}

		public IActionResult SaveDelete(int Id)
		{
			Course course = CrsRepo.GetById(x => x.Id == Id);
			CrsRepo.Remove(course);
			CrsRepo.Save();
			ViewData["ProfList"] = context.Professors.ToList();
			ViewData["DeptList"] = DeptRepo.GetAll().ToList();
			TempData["success"] = "Course Removed Successfully";
			return RedirectToAction("Index");
		}
	}
}
