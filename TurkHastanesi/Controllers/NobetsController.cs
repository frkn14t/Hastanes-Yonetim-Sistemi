using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneBolu.Models.Classes;

namespace HastaneBolu.Controllers
{
    public class NobetsController : Controller
    {
        private readonly HastaneBoluDBContext _context;

        public NobetsController(HastaneBoluDBContext context)
        {
            _context = context;
        }

        // GET: Nobets
        public async Task<IActionResult> Index()
        {
            var turkHastanesiDbContext = _context.Nobetler.Include(n => n.Asistan).Include(n => n.Department);
            return View(await turkHastanesiDbContext.ToListAsync());
        }
         public async Task<IActionResult> Calender()
        {
            var turkHastanesiDbContext = _context.Nobetler.Include(n => n.Asistan).Include(n => n.Department);
            return View(await turkHastanesiDbContext.ToListAsync());
        }
         public async Task<IActionResult> Nobetler()
        {
            var turkHastanesiDbContext = _context.Nobetler.Include(n => n.Asistan).Include(n => n.Department);
            return View(await turkHastanesiDbContext.ToListAsync());
        }
        // GET: Nobets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nobet = await _context.Nobetler
                .Include(n => n.Asistan)
                .Include(n => n.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nobet == null)
            {
                return NotFound();
            }

            return View(nobet);
        }

        // GET: Nobets/Create
        public IActionResult Create()
        {
            ViewData["AsistanId"] = new SelectList(_context.Asistanlar, "AsistanId", "AsistanId");
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id");
            return View();
        }

        // POST: Nobets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartTime,EndTime,AsistanId,DepartmentId")] Nobet nobet)
        {
          
            
                _context.Add(nobet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["AsistanId"] = new SelectList(_context.Asistanlar, "AsistanId", "AsistanId", nobet.AsistanId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", nobet.DepartmentId);
            return View(nobet);
        }

        // GET: Nobets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nobet = await _context.Nobetler.FindAsync(id);
            if (nobet == null)
            {
                return NotFound();
            }
            ViewData["AsistanId"] = new SelectList(_context.Asistanlar, "AsistanId", "AsistanId", nobet.AsistanId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", nobet.DepartmentId);
            return View(nobet);
        }

        // POST: Nobets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartTime,EndTime,AsistanId,DepartmentId")] Nobet nobet)
        {
            if (id != nobet.Id)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(nobet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NobetExists(nobet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["AsistanId"] = new SelectList(_context.Asistanlar, "AsistanId", "AsistanId", nobet.AsistanId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", nobet.DepartmentId);
            return View(nobet);
        }

        // GET: Nobets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nobet = await _context.Nobetler
                .Include(n => n.Asistan)
                .Include(n => n.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nobet == null)
            {
                return NotFound();
            }

            return View(nobet);
        }

        // POST: Nobets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nobet = await _context.Nobetler.FindAsync(id);
            if (nobet != null)
            {
                _context.Nobetler.Remove(nobet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NobetExists(int id)
        {
            return _context.Nobetler.Any(e => e.Id == id);
        }
    }
}
