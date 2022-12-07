using Inventarisation.Data;
using Inventarisation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventarisation.Controllers
{
    public class LoginController : Controller
    {

        private readonly MyAppContext _context;

        public LoginController (MyAppContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string name, string password )
        {
            Admin? admin = _context.Admins.FirstOrDefault(m => m.Name == name && m.Password == password );

            if(admin == null)
            {
                ModelState.AddModelError("","Not correct login and pass");
            }
            else
            {
                
            }
            
            return View();
        }





    }
}
