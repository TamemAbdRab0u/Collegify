using Collegify.Models;
using Collegify.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Collegify.Controllers
{
    public class GradeController : Controller
    {
        IGradeRepo GradRepo;
        AppDbContext context;
        public GradeController(IGradeRepo _GradRepo, AppDbContext _context)
        {
            this.GradRepo = _GradRepo;
            this.context = _context;
        }

        public IActionResult Index()
        {
            List<Grade> Grades = context.Grades.Include(x => x.Enrollment).ToList();
            return View(Grades);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Grade grade)
        {
            GradRepo.Add(grade);
            GradRepo.Save();
            TempData["success"] = "Grade Added Successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Grade grade = GradRepo.GetById(x => x.Id == Id);
            return View(grade);
        }

        [HttpPost]
        public IActionResult Edit(Grade grade)
        {
            GradRepo.Update(grade);
            GradRepo.Save();
            TempData["success"] = "Grade Updated Successfully";
            return RedirectToAction("Index");
        }

		public IActionResult Delete(int Id)
		{
			Grade grade = GradRepo.GetById(x => x.Id == Id);
			return View(grade);
		}

		public IActionResult SaveDelete(int Id)
		{
			Grade grade = GradRepo.GetById(x => x.Id == Id);
			GradRepo.Remove(grade);
			GradRepo.Save();
			TempData["success"] = "Grdae Removed Successfully";
			return RedirectToAction("Index");
		}
	}
}
