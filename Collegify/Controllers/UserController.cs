using Collegify.Models;
using Microsoft.AspNetCore.Mvc;
using Collegify.ViewModels;

namespace Collegify.Controllers
{
    public class UserController : Controller
    {
        private readonly UserFactory _userFactory;
        AppDbContext context;

        public UserController(AppDbContext context)
        {
            _userFactory = new UserFactory();
            this.context = context;
        }

        public IActionResult CreateUser(string role)
        {
            try
            {
                IUser user = _userFactory.CreateUser(role);
                ViewData["UserDetails"] = user;
                return View(); 
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); 
            }
        }
    }
}
