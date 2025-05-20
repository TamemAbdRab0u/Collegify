using Collegify.Models;
using Collegify.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Collegify.Controllers
{
    public class FeeController : Controller
    {
        IFeeRepo FeRepo;
        IStudentRepo StdRepo;
        AppDbContext context;
        public FeeController(IFeeRepo _FeRepo, IStudentRepo _StdRepo, AppDbContext _context)
        {
            this.FeRepo = _FeRepo;
            this.StdRepo = _StdRepo;
            this.context = _context;
        }

        public IActionResult Index()
        {
            List<Fee> fees = context.Fees.Include(x => x.Student).ToList();
            return View(fees);
        }

        public IActionResult Add()
        {
            ViewData["StdList"] = StdRepo.GetAll().ToList();
            return View();
        }

        public IActionResult SaveAdd(Fee fee)
        {
            FeRepo.Add(fee);
            FeRepo.Save();
            ViewData["StdList"] = StdRepo.GetAll().ToList();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            Fee fee = FeRepo.GetById(x => x.Id == Id);
			ViewData["StdList"] = StdRepo.GetAll().ToList();
			return View(fee);
        }

        public IActionResult SaveEdit(Fee fee)
        {
            FeRepo.Update(fee);
            FeRepo.Save();
			ViewData["StdList"] = StdRepo.GetAll().ToList();
            return RedirectToAction("Index");
		}

		public IActionResult Delete(int Id)
		{
			Fee fee = FeRepo.GetById(x => x.Id == Id);
			ViewData["StdList"] = StdRepo.GetAll().ToList();
			return View(fee);
		}

		public IActionResult SaveDelete(int Id)
		{
			Fee fee = FeRepo.GetById(x => x.Id == Id);
			FeRepo.Remove(fee);
			FeRepo.Save();
			ViewData["StdList"] = StdRepo.GetAll().ToList();
			return RedirectToAction("Index");
		}

        public IActionResult Pay()
        {
            return View();
		}
	}
}
