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
    public class UporabnikController : Controller
    {
        private readonly TrgovinaContext _context;

        public UporabnikController(TrgovinaContext context)
        {
            _context = context;
        }

        // GET: Uporabnik
        public async Task<IActionResult> Index()
        {
              return View(await _context.Uporabnik.ToListAsync());
        }

        // GET: Uporabnik/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Uporabnik == null)
            {
                return NotFound();
            }

            var uporabnik = await _context.Uporabnik
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uporabnik == null)
            {
                return NotFound();
            }

            return View(uporabnik);
        }

        // GET: Uporabnik/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Uporabnik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UporabnikId,ime,priimek,naslov,posta,stPoste,telefon,admin,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Uporabnik uporabnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uporabnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uporabnik);
        }

        // GET: Uporabnik/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Uporabnik == null)
            {
                return NotFound();
            }

            var uporabnik = await _context.Uporabnik.FindAsync(id);
            if (uporabnik == null)
            {
                return NotFound();
            }
            return View(uporabnik);
        }

        // POST: Uporabnik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UporabnikId,ime,priimek,naslov,posta,stPoste,telefon,admin,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Uporabnik uporabnik)
        {
            if (id != uporabnik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uporabnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UporabnikExists(uporabnik.Id))
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
            return View(uporabnik);
        }

        // GET: Uporabnik/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Uporabnik == null)
            {
                return NotFound();
            }

            var uporabnik = await _context.Uporabnik
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uporabnik == null)
            {
                return NotFound();
            }

            return View(uporabnik);
        }

        // POST: Uporabnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Uporabnik == null)
            {
                return Problem("Entity set 'TrgovinaContext.Uporabnik'  is null.");
            }
            var uporabnik = await _context.Uporabnik.FindAsync(id);
            if (uporabnik != null)
            {
                _context.Uporabnik.Remove(uporabnik);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UporabnikExists(string id)
        {
          return _context.Uporabnik.Any(e => e.Id == id);
        }
    }
}
