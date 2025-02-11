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
    public class KullanicisController : Controller
    {
        private readonly HastaneBoluDBContext _context;

        public KullanicisController(HastaneBoluDBContext context)
        {
            _context = context;
        }

        // GET: Kullanicis
        public async Task<IActionResult> Index()
        {
            var turkHastanesiDbContext = _context.Kullanicilar.Include(k => k.Rol);
            return View(await turkHastanesiDbContext.ToListAsync());
        }

        // GET: Kullanicis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kullanici = await _context.Kullanicilar
                .Include(k => k.Rol)
                .FirstOrDefaultAsync(m => m.KullaniciId == id);
            if (kullanici == null)
            {
                return NotFound();
            }

            return View(kullanici);
        }

        // GET: Kullanicis/Create
        public IActionResult Create()
        {
            ViewData["RolId"] = new SelectList(_context.Roller, "RolId", "RolAd");
            return View();
        }

        // POST: Kullanicis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KullaniciId,Ad,Sifre,RolId")] Kullanici kullanici)
        {
            
            
                _context.Add(kullanici);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["RolId"] = new SelectList(_context.Roller, "RolId", "RolAd", kullanici.RolId);
            return View(kullanici);
        }

        // GET: Kullanicis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kullanici = await _context.Kullanicilar.FindAsync(id);
            if (kullanici == null)
            {
                return NotFound();
            }
            ViewData["RolId"] = new SelectList(_context.Roller, "RolId", "RolAd", kullanici.RolId);
            return View(kullanici);
        }

        // POST: Kullanicis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KullaniciId,Ad,Sifre,RolId")] Kullanici kullanici)
        {
            if (id != kullanici.KullaniciId)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(kullanici);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KullaniciExists(kullanici.KullaniciId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["RolId"] = new SelectList(_context.Roller, "RolId", "RolAd", kullanici.RolId);
            return View(kullanici);
        }

        // GET: Kullanicis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kullanici = await _context.Kullanicilar
                .Include(k => k.Rol)
                .FirstOrDefaultAsync(m => m.KullaniciId == id);
            if (kullanici == null)
            {
                return NotFound();
            }

            return View(kullanici);
        }

        // POST: Kullanicis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kullanici = await _context.Kullanicilar.FindAsync(id);
            if (kullanici != null)
            {
                _context.Kullanicilar.Remove(kullanici);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KullaniciExists(int id)
        {
            return _context.Kullanicilar.Any(e => e.KullaniciId == id);
        }
    }
}
