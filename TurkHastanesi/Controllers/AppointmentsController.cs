﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneBolu.Models.Classes;

namespace HastaneBolu.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly HastaneBoluDBContext _context;

        public AppointmentsController(HastaneBoluDBContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var turkHastanesiDbContext = _context.Appointments.Include(a => a.Asistan).Include(a => a.doktor);
            return View(await turkHastanesiDbContext.ToListAsync());
        }
         public async Task<IActionResult> Randevu()
        {
            var turkHastanesiDbContext = _context.Appointments.Include(a => a.Asistan).Include(a => a.doktor);
            return View(await turkHastanesiDbContext.ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Asistan)
                .Include(a => a.doktor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["AsistanId"] = new SelectList(_context.Asistanlar, "AsistanId", "AsistanId");
            ViewData["DoktorId"] = new SelectList(_context.Doktorlar, "DoktorId", "DoktorId");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RandevuTarihi,Not,AsistanId,DoktorId")] Appointment appointment)
        {
            
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["AsistanId"] = new SelectList(_context.Asistanlar, "AsistanId", "AsistanId", appointment.AsistanId);
            ViewData["DoktorId"] = new SelectList(_context.Doktorlar, "DoktorId", "DoktorId", appointment.DoktorId);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["AsistanId"] = new SelectList(_context.Asistanlar, "AsistanId", "AsistanId", appointment.AsistanId);
            ViewData["DoktorId"] = new SelectList(_context.Doktorlar, "DoktorId", "DoktorId", appointment.DoktorId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RandevuTarihi,Not,AsistanId,DoktorId")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["AsistanId"] = new SelectList(_context.Asistanlar, "AsistanId", "AsistanId", appointment.AsistanId);
            ViewData["DoktorId"] = new SelectList(_context.Doktorlar, "DoktorId", "DoktorId", appointment.DoktorId);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Asistan)
                .Include(a => a.doktor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.Id == id);
        }
    }
}
