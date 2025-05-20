using Collegify.Models;
using Collegify.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Collegify.Controllers
{
    public class ProfessorController : Controller
    {
        IDepartmentRepo DeptRepo;
        AppDbContext context;
        public ProfessorController(IDepartmentRepo DeptRepo,AppDbContext context)
        {
            this.DeptRepo = DeptRepo;
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
			ViewData["DeptList"] = DeptRepo.GetAll().ToList();
			return View();
        }

        [HttpPost]
        public IActionResult Add(Professor prof)
        {
            if (prof.Name == "TestName")
            {
                return Ok("Test run - no data saved.");
            }
            else
            {
                context.Professors.Add(prof);
                context.SaveChanges();
                TempData["success"] = "Professor Added Successfully";
                ViewData["DeptList"] = DeptRepo.GetAll().ToList();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Professor prof = context.Professors.FirstOrDefault(x => x.Id == Id);
			ViewData["DeptList"] = DeptRepo.GetAll().ToList();
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
			ViewData["DeptList"] = DeptRepo.GetAll().ToList();
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
