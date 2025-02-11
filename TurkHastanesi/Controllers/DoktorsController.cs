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
    public class DoktorsController : Controller
    {
        private readonly HastaneBoluDBContext _context;

        public DoktorsController(HastaneBoluDBContext context)
        {
            _context = context;
        }

        // GET: Doktors
        public async Task<IActionResult> Index()
        {
            var turkHastanesiDbContext = _context.Doktorlar.Include(d => d.kullanici);
            return View(await turkHastanesiDbContext.ToListAsync());
        }
          public async Task<IActionResult> Doctors()
        {
            var turkHastanesiDbContext = _context.Doktorlar.Include(d => d.kullanici);
            return View(await turkHastanesiDbContext.ToListAsync());
        }
        // GET: Doktors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktorlar
                .Include(d => d.kullanici)
                .FirstOrDefaultAsync(m => m.DoktorId == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // GET: Doktors/Create
        public IActionResult Create()
        {
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciId");
            return View();
        }

        // POST: Doktors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoktorId,Ad,Soyad,Telefon,Email,Address,KullaniciId")] Doktor doktor)
        {
            
            
                _context.Add(doktor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciId", doktor.KullaniciId);
            return View(doktor);
        }

        // GET: Doktors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktorlar.FindAsync(id);
            if (doktor == null)
            {
                return NotFound();
            }
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciId", doktor.KullaniciId);
            return View(doktor);
        }

        // POST: Doktors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoktorId,Ad,Soyad,Telefon,Email,Address,KullaniciId")] Doktor doktor)
        {
            if (id != doktor.DoktorId)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(doktor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoktorExists(doktor.DoktorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciId", doktor.KullaniciId);
            return View(doktor);
        }

        // GET: Doktors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktorlar
                .Include(d => d.kullanici)
                .FirstOrDefaultAsync(m => m.DoktorId == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // POST: Doktors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doktor = await _context.Doktorlar.FindAsync(id);
            if (doktor != null)
            {
                _context.Doktorlar.Remove(doktor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoktorExists(int id)
        {
            return _context.Doktorlar.Any(e => e.DoktorId == id);
        }
    }
}
