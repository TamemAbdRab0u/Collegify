using Collegify.Models;
using Collegify.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Collegify.Controllers
{
	public class DepartmentController : Controller
	{
		public IDepartmentRepo DeptRepo;
        public DepartmentController(IDepartmentRepo DeptRepo)
        {
            this.DeptRepo = DeptRepo;
        }

        public IActionResult Index()
		{
			List<Department> Depts = DeptRepo.GetAll().ToList();
			return View(Depts);
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(Department Dept)
		{
			DeptRepo.Add(Dept);
			DeptRepo.Save();
            TempData["success"] = "Deparmtent Added Successfully";
            return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int Id)
		{
			Department Dept = DeptRepo.GetById(X => X.Id == Id);
			return View(Dept);
		}

		[HttpPost]
        public IActionResult Edit(Department Dept)
        {
            DeptRepo.Update(Dept);
			DeptRepo.Save();
            TempData["success"] = "Department Edited Successfully";
            return RedirectToAction("Index");
        }

		[HttpGet]
		public IActionResult Delete(int Id)
		{
			Department Dept = DeptRepo.GetById(X => X.Id == Id);
			return View(Dept);
        }

		[HttpPost]
		public IActionResult SaveDelete(int Id)
		{
            Department Dept = DeptRepo.GetById(X => X.Id == Id);
            DeptRepo.Remove(Dept);
			DeptRepo.Save();
            TempData["success"] = "Department Removed Successfully";
            return RedirectToAction("Index");

		}
    }
}
