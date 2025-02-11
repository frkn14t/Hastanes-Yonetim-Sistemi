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
    public class AsistansController : Controller
    {
        private readonly HastaneBoluDBContext _context;

        public AsistansController(HastaneBoluDBContext context)
        {
            _context = context;
        }

        // GET: Asistans
        public async Task<IActionResult> Index()
        {
            var turkHastanesiDbContext = _context.Asistanlar.Include(a => a.Department).Include(a => a.Kullanici);
            return View(await turkHastanesiDbContext.ToListAsync());
        }
        public async Task<IActionResult> Asistants()
        {
            var turkHastanesiDbContext = _context.Asistanlar.Include(a => a.Department).Include(a => a.Kullanici);
            return View(await turkHastanesiDbContext.ToListAsync());
        }
        // GET: Asistans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistan = await _context.Asistanlar
                .Include(a => a.Department)
                .Include(a => a.Kullanici)
                .FirstOrDefaultAsync(m => m.AsistanId == id);
            if (asistan == null)
            {
                return NotFound();
            }

            return View(asistan);
        }

        // GET: Asistans/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id");
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciId");
            return View();
        }

        // POST: Asistans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AsistanId,Ad,Soyad,Telefon,Email,Address,KullaniciId,DepartmentId")] Asistan asistan)
        {
           
                _context.Add(asistan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", asistan.DepartmentId);
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciId", asistan.KullaniciId);
            return View(asistan);
        }

        // GET: Asistans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistan = await _context.Asistanlar.FindAsync(id);
            if (asistan == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", asistan.DepartmentId);
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciId", asistan.KullaniciId);
            return View(asistan);
        }

        // POST: Asistans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AsistanId,Ad,Soyad,Telefon,Email,Address,KullaniciId,DepartmentId")] Asistan asistan)
        {
            if (id != asistan.AsistanId)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(asistan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsistanExists(asistan.AsistanId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", asistan.DepartmentId);
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciId", asistan.KullaniciId);
            return View(asistan);
        }

        // GET: Asistans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistan = await _context.Asistanlar
                .Include(a => a.Department)
                .Include(a => a.Kullanici)
                .FirstOrDefaultAsync(m => m.AsistanId == id);
            if (asistan == null)
            {
                return NotFound();
            }

            return View(asistan);
        }

        // POST: Asistans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asistan = await _context.Asistanlar.FindAsync(id);
            if (asistan != null)
            {
                _context.Asistanlar.Remove(asistan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsistanExists(int id)
        {
            return _context.Asistanlar.Any(e => e.AsistanId == id);
        }
    }
}
