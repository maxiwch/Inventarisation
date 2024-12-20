﻿#nullable disable
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
    public class DevicesController : Controller
    {
        private readonly MyAppContext _context;

        public DevicesController(MyAppContext context)
        {
            _context = context;
        }

        // GET: Devices
        public async Task<IActionResult> Index()
        {
            var myAppContext = _context.Devices.Include(d => d.Producer).Include(d => d.Status).Include(d => d.TypeOfDevice);
            return View(await myAppContext.ToListAsync());
        }

        // GET: Devices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Devices
                .Include(d => d.Producer)
                .Include(d => d.Status)
                .Include(d => d.TypeOfDevice)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Name");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", 1011);
            ViewData["TypeOfDeviceId"] = new SelectList(_context.TypesOfDevices, "Id", "Name");
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,TypeOfDeviceId,ProducerId,DataOfPurchace,StatusId,Comments,SerialNumber")] Device device)
        {
            string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
            if (ModelState.IsValid)
            {
                _context.Add(device);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Errors"] = messages;
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Name", device.ProducerId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", device.StatusId);
            ViewData["TypeOfDeviceId"] = new SelectList(_context.TypesOfDevices, "Id", "Name", device.TypeOfDeviceId);
            return View(device);
        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Name", device.ProducerId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", device.StatusId);
            ViewData["TypeOfDeviceId"] = new SelectList(_context.TypesOfDevices, "Id", "Name", device.TypeOfDeviceId);
            return View(device);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,TypeOfDeviceId,ProducerId,DataOfPurchace,StatusId,Comments,SerialNumber")] Device device)
        {
            if (id != device.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(device);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceExists(device.Id))
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
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Name", device.ProducerId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", device.StatusId);
            ViewData["TypeOfDeviceId"] = new SelectList(_context.TypesOfDevices, "Id", "Name", device.TypeOfDeviceId);
            return View(device);
        }

        // GET: Devices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Devices
                .Include(d => d.Producer)
                .Include(d => d.Status)
                .Include(d => d.TypeOfDevice)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceExists(int id)
        {
            return _context.Devices.Any(e => e.Id == id);
        }
    }
}
