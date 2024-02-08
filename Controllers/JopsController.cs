using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LearningManagementSystem.Data;
using Microsoft.AspNetCore.Authorization;

namespace LearningManagementSystem.Controllers
{
    [Authorize("Authorization")]
    public class JopsController : Controller
    {
        private readonly Teat2Context _context;

        public JopsController(Teat2Context context)
        {
            _context = context;
        }

        // GET: Jops
        public async Task<IActionResult> Index()
        {
              return _context.Jops != null ? 
                          View(await _context.Jops.ToListAsync()) :
                          Problem("Entity set 'Teat2Context.Jops'  is null.");
        }

        // GET: Jops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jops == null)
            {
                return NotFound();
            }

            var jop = await _context.Jops
                .FirstOrDefaultAsync(m => m.Idjops == id);
            if (jop == null)
            {
                return NotFound();
            }

            return View(jop);
        }

        // GET: Jops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idjops,JopName")] Jop jop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jop);
        }

        // GET: Jops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jops == null)
            {
                return NotFound();
            }

            var jop = await _context.Jops.FindAsync(id);
            if (jop == null)
            {
                return NotFound();
            }
            return View(jop);
        }

        // POST: Jops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idjops,JopName")] Jop jop)
        {
            if (id != jop.Idjops)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JopExists(jop.Idjops))
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
            return View(jop);
        }

        // GET: Jops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jops == null)
            {
                return NotFound();
            }

            var jop = await _context.Jops
                .FirstOrDefaultAsync(m => m.Idjops == id);
            if (jop == null)
            {
                return NotFound();
            }

            return View(jop);
        }

        // POST: Jops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Jops == null)
            {
                return Problem("Entity set 'Teat2Context.Jops'  is null.");
            }
            var jop = await _context.Jops.FindAsync(id);
            if (jop != null)
            {
                _context.Jops.Remove(jop);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JopExists(int id)
        {
          return (_context.Jops?.Any(e => e.Idjops == id)).GetValueOrDefault();
        }
    }
}
