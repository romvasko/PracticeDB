using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticeDB.Data;
using PracticeDB.Models;

namespace PracticeDB.Controllers
{
    public class VisitorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VisitorsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Sort()
        {
              return View(await _context.visitors.OrderBy(x=>x.VisitorName).ToListAsync());
        }
        // GET: Visitors
        public async Task<IActionResult> Index()
        {
              return View(await _context.visitors.ToListAsync());
        }

        // GET: Visitors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.visitors == null)
            {
                return NotFound();
            }

            var visitor = await _context.visitors
                .FirstOrDefaultAsync(m => m.VisitorId == id);
            if (visitor == null)
            {
                return NotFound();
            }

            return View(visitor);
        }

        // GET: Visitors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Visitors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VisitorId,VisitorName,VisitorPassport")] Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(visitor);
        }

        // GET: Visitors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.visitors == null)
            {
                return NotFound();
            }

            var visitor = await _context.visitors.FindAsync(id);
            if (visitor == null)
            {
                return NotFound();
            }
            return View(visitor);
        }

        // POST: Visitors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VisitorId,VisitorName,VisitorPassport")] Visitor visitor)
        {
            if (id != visitor.VisitorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitorExists(visitor.VisitorId))
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
            return View(visitor);
        }

        // GET: Visitors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.visitors == null)
            {
                return NotFound();
            }

            var visitor = await _context.visitors
                .FirstOrDefaultAsync(m => m.VisitorId == id);
            if (visitor == null)
            {
                return NotFound();
            }

            return View(visitor);
        }

        // POST: Visitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.visitors == null)
            {
                return Problem("Entity set 'ApplicationDbContext.visitors'  is null.");
            }
            var visitor = await _context.visitors.FindAsync(id);
            if (visitor != null)
            {
                _context.visitors.Remove(visitor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitorExists(int id)
        {
          return _context.visitors.Any(e => e.VisitorId == id);
        }
    }
}
