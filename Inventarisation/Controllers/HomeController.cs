using Inventarisation.Data;
using Inventarisation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Inventarisation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyAppContext _myAppContext;

        public HomeController(ILogger<HomeController> logger, MyAppContext myAppContext )
        {
            _logger = logger;
            _myAppContext = myAppContext;
        }

        public IActionResult Index()
        {
            //string? str = "Hello" ;
            //int a;
            //if(str != null)
            //{
            //    a = str.Length ;
            //}
            //else
            //{
            //    a = 0 ;
            //}

            //a = str !=null ? str.Length : 0 ;
            //a = str?.Length;

            //string msg = "text";
            //msg = str ?? "если равно null" ; 
            string str = "Hello";
            ViewBag.Name = str;
            ViewBag.Time = DateTime.Now.ToShortDateString();
            ViewData["year"] = DateTime.Now.Year;
            ViewBag.year = 1000;
    
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}