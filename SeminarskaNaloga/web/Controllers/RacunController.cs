using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeminarskaNaloga.Data;
using SeminarskaNaloga.Models;
using Microsoft.AspNetCore.Authorization;

namespace SeminarskaNaloga.Controllers
{
    [Authorize]
    public class RacunController : Controller
    {
        private readonly TrgovinaContext _context;

        public RacunController(TrgovinaContext context)
        {
            _context = context;
        }

        // GET: Racun
        public async Task<IActionResult> Index()
        {
            var trgovinaContext = _context.Racun.Include(r => r.Narocilo).Include(r => r.Uporabnik);
            return View(await trgovinaContext.ToListAsync());
        }

        // GET: Racun/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Racun == null)
            {
                return NotFound();
            }

            var racun = await _context.Racun
                .Include(r => r.Narocilo)
                .Include(r => r.Uporabnik)
                .FirstOrDefaultAsync(m => m.RacunId == id);
            if (racun == null)
            {
                return NotFound();
            }

            return View(racun);
        }

        // GET: Racun/Create
        public IActionResult Create()
        {
            ViewData["NarociloId"] = new SelectList(_context.Narocilo, "NarociloId", "NarociloId");
            ViewData["UporabnikId"] = new SelectList(_context.Uporabnik, "UporabnikId", "UporabnikId");
            return View();
        }

        // POST: Racun/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RacunId,datum,kolicina,cena,postnina,UporabnikId,NarociloId")] Racun racun)
        {
            if (ModelState.IsValid)
            {
                _context.Add(racun);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NarociloId"] = new SelectList(_context.Narocilo, "NarociloId", "NarociloId", racun.NarociloId);
            ViewData["UporabnikId"] = new SelectList(_context.Uporabnik, "UporabnikId", "UporabnikId", racun.UporabnikId);
            return View(racun);
        }

        // GET: Racun/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Racun == null)
            {
                return NotFound();
            }

            var racun = await _context.Racun.FindAsync(id);
            if (racun == null)
            {
                return NotFound();
            }
            ViewData["NarociloId"] = new SelectList(_context.Narocilo, "NarociloId", "NarociloId", racun.NarociloId);
            ViewData["UporabnikId"] = new SelectList(_context.Uporabnik, "UporabnikId", "UporabnikId", racun.UporabnikId);
            return View(racun);
        }

        // POST: Racun/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RacunId,datum,kolicina,cena,postnina,UporabnikId,NarociloId")] Racun racun)
        {
            if (id != racun.RacunId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(racun);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RacunExists(racun.RacunId))
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
            ViewData["NarociloId"] = new SelectList(_context.Narocilo, "NarociloId", "NarociloId", racun.NarociloId);
            ViewData["UporabnikId"] = new SelectList(_context.Uporabnik, "UporabnikId", "UporabnikId", racun.UporabnikId);
            return View(racun);
        }

        // GET: Racun/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Racun == null)
            {
                return NotFound();
            }

            var racun = await _context.Racun
                .Include(r => r.Narocilo)
                .Include(r => r.Uporabnik)
                .FirstOrDefaultAsync(m => m.RacunId == id);
            if (racun == null)
            {
                return NotFound();
            }

            return View(racun);
        }

        // POST: Racun/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Racun == null)
            {
                return Problem("Entity set 'TrgovinaContext.Racun'  is null.");
            }
            var racun = await _context.Racun.FindAsync(id);
            if (racun != null)
            {
                _context.Racun.Remove(racun);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RacunExists(int id)
        {
          return _context.Racun.Any(e => e.RacunId == id);
        }
    }
}
