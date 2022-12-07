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
    public class TransfersController : Controller
    {
        private readonly MyAppContext _context;

        public TransfersController(MyAppContext context)
        {
            _context = context;
        }

        // GET: Transfers
        public async Task<IActionResult> Index()
        {
            var myAppContext = _context.Transfers.Include(t => t.Device).Include(t => t.Employee).Include(t => t.Employee.Department)
                .Include(t=>t.Device.TypeOfDevice).Include(t=>t.Device.Producer);
            return View(await myAppContext.ToListAsync());
        }

        // GET: Transfers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transfer = await _context.Transfers
                .Include(t => t.Device)
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transfer == null)
            {
                return NotFound();
            }

            return View(transfer);
        }

        // GET: Transfers/Create
        public IActionResult Create()
        {
            ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name");
            ViewData["EmployeesId"] = new SelectList(_context.Employees, "Id", "Name");
            return View();
        }

        // POST: Transfers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,DeviceId,DateStart,CommentsStart,DateEnd,CommentsEnd,Id")] Transfer transfer)
        {
            transfer.Employee =_context.Employees.Find(transfer.EmployeeId);
            transfer.Device = _context.Devices.Find(transfer.DeviceId);

            
            ModelState.ClearValidationState(nameof(Transfer));
            bool isOk = TryValidateModel(transfer, nameof(Transfer));

            string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));



            if (ModelState.IsValid)
            {
                
                _context.Add(transfer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name", transfer.DeviceId);
            ViewData["EmployeesId"] = new SelectList(_context.Employees, "Id", "Name", transfer.EmployeeId);
            ViewData["ErrorMessage"] = messages;
            return View(transfer);
        }

        // GET: Transfers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transfer = await _context.Transfers.FindAsync(id);
            if (transfer == null)
            {
                return NotFound();
            }
            ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name", transfer.DeviceId);
            ViewData["EmployeesId"] = new SelectList(_context.Employees, "Id", "Name", transfer.EmployeeId);
            return View(transfer);
        }

        // POST: Transfers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,DeviceId,DateStart,CommentsStart,DateEnd,CommentsEnd,Id")] Transfer transfer)
        {
            if (id != transfer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transfer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransferExists(transfer.Id))
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
            ViewData["DeviceId"] = new SelectList(_context.Devices, "Id", "Name", transfer.DeviceId);
            ViewData["EmployeesId"] = new SelectList(_context.Employees, "Id", "Name", transfer.EmployeeId);
            return View(transfer);
        }

        // GET: Transfers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transfer = await _context.Transfers
                .Include(t => t.Device)
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transfer == null)
            {
                return NotFound();
            }

            return View(transfer);
        }

        // POST: Transfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transfer = await _context.Transfers.FindAsync(id);
            _context.Transfers.Remove(transfer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransferExists(int id)
        {
            return _context.Transfers.Any(e => e.Id == id);
        }
    }
}
