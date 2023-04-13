using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FakeZuydInlog.Data;
using FakeZuydInlog.Models;

namespace FakeZuydInlog.Controllers
{
    public class InlogsController : Controller
    {
        private readonly FakeZuydInlogContext _context;

        public InlogsController(FakeZuydInlogContext context)
        {
            _context = context;
        }

        // GET: Inlogs
        public async Task<IActionResult> Index()
        {
              return _context.Inlog != null ? 
                          View(await _context.Inlog.ToListAsync()) :
                          Problem("Entity set 'FakeZuydInlogContext.Inlog'  is null.");
        }

        // GET: Inlogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inlog == null)
            {
                return NotFound();
            }

            var inlog = await _context.Inlog
                .FirstOrDefaultAsync(m => m.ID == id);
            if (inlog == null)
            {
                return NotFound();
            }

            return View(inlog);
        }

        // GET: Inlogs/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Start()
        {
            return View();
        }

        // POST: Inlogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Gebruikersnaam,Wachtwoord")] Inlog inlog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inlog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inlog);
        }

        // GET: Inlogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inlog == null)
            {
                return NotFound();
            }

            var inlog = await _context.Inlog.FindAsync(id);
            if (inlog == null)
            {
                return NotFound();
            }
            return View(inlog);
        }

        // POST: Inlogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Gebruikersnaam,Wachtwoord")] Inlog inlog)
        {
            if (id != inlog.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inlog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InlogExists(inlog.ID))
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
            return View(inlog);
        }

        // GET: Inlogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inlog == null)
            {
                return NotFound();
            }

            var inlog = await _context.Inlog
                .FirstOrDefaultAsync(m => m.ID == id);
            if (inlog == null)
            {
                return NotFound();
            }

            return View(inlog);
        }

        // POST: Inlogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inlog == null)
            {
                return Problem("Entity set 'FakeZuydInlogContext.Inlog'  is null.");
            }
            var inlog = await _context.Inlog.FindAsync(id);
            if (inlog != null)
            {
                _context.Inlog.Remove(inlog);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InlogExists(int id)
        {
          return (_context.Inlog?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
