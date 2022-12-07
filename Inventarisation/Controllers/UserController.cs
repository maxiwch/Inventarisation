using Inventarisation.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventarisation.Controllers
{
    public class UserController : Controller
    {
        private readonly MyAppContext _context;
        public UserController(MyAppContext context)
        {
            _context = context;
        }
        int userId = 1;
        public IActionResult Index(string btnradio)
        
        {

        
                var data = _context.Transfers.Where(n => n.EmployeeId == userId).ToList();
            var user = _context.Employees./*Include(n => n.Department).*/FirstOrDefault(n => n.Id == userId);


            if(user == null)
            {
                return NotFound();
            }

            bool isOn = false ;
            if (btnradio =="on")
            {
                data = data.Where(n => n.DateEnd == null).ToList();
                isOn = true;
            }

            ViewBag.check1 = (isOn == true) ? "checked" : "";
            ViewBag.check2 = (isOn == true) ? "" : "checked";

            string fio = user.Name;
            string? deps = user.Department?.Name;
            ViewBag.fio = fio;
            ViewBag.deps = deps;
            return View(data);
        }
    }
}
