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
    public class EJobsController : Controller
    {
        private readonly Teat2Context _context;

        public EJobsController(Teat2Context context)
        {
            _context = context;
        }

        // GET: EJobs
        public async Task<IActionResult> Index()
        {
            var teat2Context = _context.EJobs.Include(e => e.Employee).Include(e => e.Job);
            return View(await teat2Context.ToListAsync());
        }

        // GET: EJobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EJobs == null)
            {
                return NotFound();
            }

            var eJob = await _context.EJobs
                .Include(e => e.Employee)
                .Include(e => e.Job)
                .FirstOrDefaultAsync(m => m.EJobsId == id);
            if (eJob == null)
            {
                return NotFound();
            }

            return View(eJob);
        }

        // GET: EJobs/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "IdEmployees", "IdEmployees");
            ViewData["JobId"] = new SelectList(_context.Jops, "Idjops", "Idjops");
            return View();
        }

        // POST: EJobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EJobsId,EmployeeId,JobId")] EJob eJob)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eJob);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "IdEmployees", "IdEmployees", eJob.EmployeeId);
            ViewData["JobId"] = new SelectList(_context.Jops, "Idjops", "Idjops", eJob.JobId);
            return View(eJob);
        }

        // GET: EJobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EJobs == null)
            {
                return NotFound();
            }

            var eJob = await _context.EJobs.FindAsync(id);
            if (eJob == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "IdEmployees", "IdEmployees", eJob.EmployeeId);
            ViewData["JobId"] = new SelectList(_context.Jops, "Idjops", "Idjops", eJob.JobId);
            return View(eJob);
        }

        // POST: EJobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EJobsId,EmployeeId,JobId")] EJob eJob)
        {
            if (id != eJob.EJobsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eJob);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EJobExists(eJob.EJobsId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "IdEmployees", "IdEmployees", eJob.EmployeeId);
            ViewData["JobId"] = new SelectList(_context.Jops, "Idjops", "Idjops", eJob.JobId);
            return View(eJob);
        }

        // GET: EJobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EJobs == null)
            {
                return NotFound();
            }

            var eJob = await _context.EJobs
                .Include(e => e.Employee)
                .Include(e => e.Job)
                .FirstOrDefaultAsync(m => m.EJobsId == id);
            if (eJob == null)
            {
                return NotFound();
            }

            return View(eJob);
        }

        // POST: EJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EJobs == null)
            {
                return Problem("Entity set 'Teat2Context.EJobs'  is null.");
            }
            var eJob = await _context.EJobs.FindAsync(id);
            if (eJob != null)
            {
                _context.EJobs.Remove(eJob);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EJobExists(int id)
        {
          return _context.EJobs.Any(e => e.EJobsId == id);
        }
    }
}
