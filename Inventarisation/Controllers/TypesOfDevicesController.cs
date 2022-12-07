#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inventarisation.Data;
using Inventarisation.Models;

namespace Inventarisation.Controllers
{
    public class TypesOfDevicesController : Controller
    {
        private readonly MyAppContext _context;

        public TypesOfDevicesController(MyAppContext context)
        {
            _context = context;
        }

        // GET: TypesOfDevices
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypesOfDevices.OrderBy(b=> b.Id).ToListAsync());
        }

        // GET: TypesOfDevices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typesOfDevice = await _context.TypesOfDevices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typesOfDevice == null)
            {
                return NotFound();
            }

            return View(typesOfDevice);
        }

        // GET: TypesOfDevices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypesOfDevices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] TypesOfDevice typesOfDevice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typesOfDevice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typesOfDevice);
        }

        // GET: TypesOfDevices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typesOfDevice = await _context.TypesOfDevices.FindAsync(id);
            if (typesOfDevice == null)
            {
                return NotFound();
            }
            return View(typesOfDevice);
        }

        // POST: TypesOfDevices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] TypesOfDevice typesOfDevice)
        {
            if (id != typesOfDevice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typesOfDevice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypesOfDeviceExists(typesOfDevice.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(typesOfDevice);
        }

        // GET: TypesOfDevices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typesOfDevice = await _context.TypesOfDevices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typesOfDevice == null)
            {
                return NotFound();
            }

            return View(typesOfDevice);
        }

        // POST: TypesOfDevices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typesOfDevice = await _context.TypesOfDevices.FindAsync(id);
            _context.TypesOfDevices.Remove(typesOfDevice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypesOfDeviceExists(int id)
        {
            return _context.TypesOfDevices.Any(e => e.Id == id);
        }
    }
}
