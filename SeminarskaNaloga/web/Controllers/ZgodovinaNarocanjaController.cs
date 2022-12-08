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
    public class ZgodovinaNarocanjaController : Controller
    {
        private readonly TrgovinaContext _context;

        public ZgodovinaNarocanjaController(TrgovinaContext context)
        {
            _context = context;
        }

        // GET: ZgodovinaNarocanja
        public async Task<IActionResult> Index()
        {
              return View(await _context.ZgodovinaNarocanja.ToListAsync());
        }

        // GET: ZgodovinaNarocanja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ZgodovinaNarocanja == null)
            {
                return NotFound();
            }

            var zgodovinaNarocanja = await _context.ZgodovinaNarocanja
                .FirstOrDefaultAsync(m => m.ZgodovinaNarocanjaId == id);
            if (zgodovinaNarocanja == null)
            {
                return NotFound();
            }

            return View(zgodovinaNarocanja);
        }

        // GET: ZgodovinaNarocanja/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZgodovinaNarocanja/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZgodovinaNarocanjaId")] ZgodovinaNarocanja zgodovinaNarocanja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zgodovinaNarocanja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zgodovinaNarocanja);
        }

        // GET: ZgodovinaNarocanja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ZgodovinaNarocanja == null)
            {
                return NotFound();
            }

            var zgodovinaNarocanja = await _context.ZgodovinaNarocanja.FindAsync(id);
            if (zgodovinaNarocanja == null)
            {
                return NotFound();
            }
            return View(zgodovinaNarocanja);
        }

        // POST: ZgodovinaNarocanja/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZgodovinaNarocanjaId")] ZgodovinaNarocanja zgodovinaNarocanja)
        {
            if (id != zgodovinaNarocanja.ZgodovinaNarocanjaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zgodovinaNarocanja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZgodovinaNarocanjaExists(zgodovinaNarocanja.ZgodovinaNarocanjaId))
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
            return View(zgodovinaNarocanja);
        }

        // GET: ZgodovinaNarocanja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ZgodovinaNarocanja == null)
            {
                return NotFound();
            }

            var zgodovinaNarocanja = await _context.ZgodovinaNarocanja
                .FirstOrDefaultAsync(m => m.ZgodovinaNarocanjaId == id);
            if (zgodovinaNarocanja == null)
            {
                return NotFound();
            }

            return View(zgodovinaNarocanja);
        }

        // POST: ZgodovinaNarocanja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ZgodovinaNarocanja == null)
            {
                return Problem("Entity set 'TrgovinaContext.ZgodovinaNarocanja'  is null.");
            }
            var zgodovinaNarocanja = await _context.ZgodovinaNarocanja.FindAsync(id);
            if (zgodovinaNarocanja != null)
            {
                _context.ZgodovinaNarocanja.Remove(zgodovinaNarocanja);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZgodovinaNarocanjaExists(int id)
        {
          return _context.ZgodovinaNarocanja.Any(e => e.ZgodovinaNarocanjaId == id);
        }
    }
}
