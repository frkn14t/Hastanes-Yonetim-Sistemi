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
    public class AcilDurumsController : Controller
    {
        private readonly HastaneBoluDBContext _context;

        public AcilDurumsController(HastaneBoluDBContext context)
        {
            _context = context;
        }

        // GET: AcilDurums
        public async Task<IActionResult> Index()
        {
            return View(await _context.AcilDurumlar.ToListAsync());
        }
         public async Task<IActionResult> AcilDurum()
        {
            return View(await _context.AcilDurumlar.ToListAsync());
        }
        // GET: AcilDurums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acilDurum = await _context.AcilDurumlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acilDurum == null)
            {
                return NotFound();
            }

            return View(acilDurum);
        }

        // GET: AcilDurums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AcilDurums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Aciklama,CreatedAt")] AcilDurum acilDurum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acilDurum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acilDurum);
        }

        // GET: AcilDurums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acilDurum = await _context.AcilDurumlar.FindAsync(id);
            if (acilDurum == null)
            {
                return NotFound();
            }
            return View(acilDurum);
        }

        // POST: AcilDurums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Aciklama,CreatedAt")] AcilDurum acilDurum)
        {
            if (id != acilDurum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acilDurum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcilDurumExists(acilDurum.Id))
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
            return View(acilDurum);
        }

        // GET: AcilDurums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acilDurum = await _context.AcilDurumlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acilDurum == null)
            {
                return NotFound();
            }

            return View(acilDurum);
        }

        // POST: AcilDurums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acilDurum = await _context.AcilDurumlar.FindAsync(id);
            if (acilDurum != null)
            {
                _context.AcilDurumlar.Remove(acilDurum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcilDurumExists(int id)
        {
            return _context.AcilDurumlar.Any(e => e.Id == id);
        }
    }
}
