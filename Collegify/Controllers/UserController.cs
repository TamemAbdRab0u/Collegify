using Collegify.Models;
using Microsoft.AspNetCore.Mvc;

namespace Collegify.Controllers
{
    public class UserController : Controller
    {
        private readonly UserFactory _userFactory;

        public UserController()
        {
            _userFactory = new UserFactory();
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
