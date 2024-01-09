using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LearningManagementSystem.Data;

namespace LearningManagementSystem.Controllers
{
    public class EMedelsController : Controller
    {
        private readonly Teat2Context _context;

        public EMedelsController(Teat2Context context)
        {
            _context = context;
        }

        // GET: EMedels
        public async Task<IActionResult> Index()
        {
            var teat2Context = _context.EMedels.Include(e => e.IdemployeesNavigation).Include(e => e.Medals);
            return View(await teat2Context.ToListAsync());
        }

        // GET: EMedels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EMedels == null)
            {
                return NotFound();
            }

            var eMedel = await _context.EMedels
                .Include(e => e.IdemployeesNavigation)
                .Include(e => e.Medals)
                .FirstOrDefaultAsync(m => m.IdeMedals == id);
            if (eMedel == null)
            {
                return NotFound();
            }

            return View(eMedel);
        }

        // GET: EMedels/Create
        public IActionResult Create()
        {
            ViewData["Idemployees"] = new SelectList(_context.Employees, "IdEmployees", "IdEmployees");
            ViewData["MedalsId"] = new SelectList(_context.Medels, "Idmedels", "Idmedels");
            return View();
        }

        // POST: EMedels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdeMedals,MedalsId,DateMedals,Idemployees")] EMedel eMedel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eMedel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idemployees"] = new SelectList(_context.Employees, "IdEmployees", "IdEmployees", eMedel.Idemployees);
            ViewData["MedalsId"] = new SelectList(_context.Medels, "Idmedels", "Idmedels", eMedel.MedalsId);
            return View(eMedel);
        }

        // GET: EMedels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EMedels == null)
            {
                return NotFound();
            }

            var eMedel = await _context.EMedels.FindAsync(id);
            if (eMedel == null)
            {
                return NotFound();
            }
            ViewData["Idemployees"] = new SelectList(_context.Employees, "IdEmployees", "IdEmployees", eMedel.Idemployees);
            ViewData["MedalsId"] = new SelectList(_context.Medels, "Idmedels", "Idmedels", eMedel.MedalsId);
            return View(eMedel);
        }

        // POST: EMedels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdeMedals,MedalsId,DateMedals,Idemployees")] EMedel eMedel)
        {
            if (id != eMedel.IdeMedals)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eMedel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EMedelExists(eMedel.IdeMedals))
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
            ViewData["Idemployees"] = new SelectList(_context.Employees, "IdEmployees", "IdEmployees", eMedel.Idemployees);
            ViewData["MedalsId"] = new SelectList(_context.Medels, "Idmedels", "Idmedels", eMedel.MedalsId);
            return View(eMedel);
        }

        // GET: EMedels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EMedels == null)
            {
                return NotFound();
            }

            var eMedel = await _context.EMedels
                .Include(e => e.IdemployeesNavigation)
                .Include(e => e.Medals)
                .FirstOrDefaultAsync(m => m.IdeMedals == id);
            if (eMedel == null)
            {
                return NotFound();
            }

            return View(eMedel);
        }

        // POST: EMedels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EMedels == null)
            {
                return Problem("Entity set 'Teat2Context.EMedels'  is null.");
            }
            var eMedel = await _context.EMedels.FindAsync(id);
            if (eMedel != null)
            {
                _context.EMedels.Remove(eMedel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EMedelExists(int id)
        {
          return _context.EMedels.Any(e => e.IdeMedals == id);
        }
    }
}
