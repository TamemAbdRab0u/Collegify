using Collegify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Collegify.Controllers
{
    public class ProfessorController : Controller
    {
        AppDbContext context;
        public ProfessorController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Professor> profs = context.Professors.Include(x => x.Department).ToList();
            return View(profs);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Professor prof)
        {
            context.Professors.Add(prof);
            context.SaveChanges();
            TempData["success"] = "Professor Added Successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Professor prof = context.Professors.FirstOrDefault(x => x.Id == Id);
            return View(prof);
        }

        [HttpPost]
        public IActionResult Edit(Professor NewProf)
        {
            Professor OldProf = context.Professors.FirstOrDefault(x => x.Id == NewProf.Id);
            OldProf.Name = NewProf.Name;
            OldProf.Email = NewProf.Email;
            OldProf.Phone = NewProf.Phone;
            OldProf.HireDate = NewProf.HireDate;
            OldProf.DepartmentID = NewProf.DepartmentID;

            context.SaveChanges();
            TempData["success"] = "Professor Edited Successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
			Professor prof = context.Professors.FirstOrDefault(x => x.Id == Id);
			return View("Delete",prof);
		}

        public IActionResult SaveDelete(int Id)
        {
			Professor prof = context.Professors.FirstOrDefault(x => x.Id == Id);
            context.Professors.Remove(prof);
            context.SaveChanges();
            TempData["success"] = "Professor Removed Successfully";
            return RedirectToAction("Index");
		}
    }
}
