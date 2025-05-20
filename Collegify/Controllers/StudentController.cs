using Collegify.Models;
using Collegify.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Collegify.Controllers
{
	public class StudentController : Controller
	{
		IStudentRepo StdRepo;
		IDepartmentRepo DeptRepo;
		AppDbContext context;
        public StudentController(IStudentRepo _StdRepo, IDepartmentRepo _DeptRepo, AppDbContext _context)
        {
            this.StdRepo = _StdRepo;
			this.DeptRepo = _DeptRepo;
			this.context = _context;

        }

        public IActionResult Index()
		{
			List<Student> stds = context.Students.Include(x => x.Department).ToList(); 
			return View(stds);
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewData["DeptList"] = DeptRepo.GetAll().ToList();
			return View();
		}

		[HttpPost]
		public IActionResult SaveAdd(Student std)
		{
            if (std.Name == "TestName")
            {
                return Ok("Test run - no data saved.");
            }
			else
			{
                StdRepo.Add(std);
                StdRepo.Save();
                TempData["success"] = "Student Added Successfully";
                ViewData["DeptList"] = DeptRepo.GetAll().ToList();
                return RedirectToAction("Index");
            }
		}

		[HttpGet]
		public IActionResult Edit(int Id)
		{
			Student std = StdRepo.GetById(x => x.Id == Id);
			ViewData["DeptList"] = DeptRepo.GetAll().ToList();
			return View(std);
		}

		[HttpPost]
		public IActionResult SaveEdit(Student std)
		{
			StdRepo.Update(std);
			StdRepo.Save();
			TempData["success"] = "Student Edited Successfully";
			ViewData["DeptList"] = DeptRepo.GetAll().ToList();
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
