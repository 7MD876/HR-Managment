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
    public class MedelsController : Controller
    {
        private readonly Teat2Context _context;

        public MedelsController(Teat2Context context)
        {
            _context = context;
        }

        // GET: Medels
        public async Task<IActionResult> Index()
        {
              return View(await _context.Medels.ToListAsync());
        }

        // GET: Medels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medels == null)
            {
                return NotFound();
            }

            var medel = await _context.Medels
                .FirstOrDefaultAsync(m => m.Idmedels == id);
            if (medel == null)
            {
                return NotFound();
            }

            return View(medel);
        }

        // GET: Medels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idmedels,MedelsName")] Medel medel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medel);
        }

        // GET: Medels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medels == null)
            {
                return NotFound();
            }

            var medel = await _context.Medels.FindAsync(id);
            if (medel == null)
            {
                return NotFound();
            }
            return View(medel);
        }

        // POST: Medels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idmedels,MedelsName")] Medel medel)
        {
            if (id != medel.Idmedels)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedelExists(medel.Idmedels))
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
            return View(medel);
        }

        // GET: Medels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medels == null)
            {
                return NotFound();
            }

            var medel = await _context.Medels
                .FirstOrDefaultAsync(m => m.Idmedels == id);
            if (medel == null)
            {
                return NotFound();
            }

            return View(medel);
        }

        // POST: Medels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medels == null)
            {
                return Problem("Entity set 'Teat2Context.Medels'  is null.");
            }
            var medel = await _context.Medels.FindAsync(id);
            if (medel != null)
            {
                _context.Medels.Remove(medel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedelExists(int id)
        {
          return _context.Medels.Any(e => e.Idmedels == id);
        }
    }
}
