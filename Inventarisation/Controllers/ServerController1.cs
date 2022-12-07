using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventarisation.Controllers
{
    public class ServerController1 : Controller
    {
        // GET: ServerController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: ServerController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServerController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServerController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServerController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServerController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServerController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServerController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
