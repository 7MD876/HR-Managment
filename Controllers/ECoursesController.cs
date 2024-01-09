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
    public class ECoursesController : Controller
    {
        private readonly Teat2Context _context;

        public ECoursesController(Teat2Context context)
        {
            _context = context;
        }

        // GET: ECourses
        public async Task<IActionResult> Index()
        {
            var teat2Context = _context.ECourses.Include(e => e.Course).Include(e => e.IdemployeesNavigation);
            return View(await teat2Context.ToListAsync());
        }

        // GET: ECourses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ECourses == null)
            {
                return NotFound();
            }

            var eCourse = await _context.ECourses
                .Include(e => e.Course)
                .Include(e => e.IdemployeesNavigation)
                .FirstOrDefaultAsync(m => m.IdemployeesCourses == id);
            if (eCourse == null)
            {
                return NotFound();
            }

            return View(eCourse);
        }

        // GET: ECourses/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName");
            ViewData["Idemployees"] = new SelectList(_context.Employees, "IdEmployees", "Name");
            return View();
        }

        // POST: ECourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdemployeesCourses,Idemployees,CourseId,StartDate,EndDate,Rating")] ECourse eCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", eCourse.CourseId);
            ViewData["Idemployees"] = new SelectList(_context.Employees, "IdEmployees", "Name", eCourse.Idemployees);
            return View(eCourse);
        }

        // GET: ECourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ECourses == null)
            {
                return NotFound();
            }

            var eCourse = await _context.ECourses.FindAsync(id);
            if (eCourse == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", eCourse.CourseId);
            ViewData["Idemployees"] = new SelectList(_context.Employees, "IdEmployees", "Name", eCourse.Idemployees);
            return View(eCourse);
        }

        // POST: ECourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdemployeesCourses,Idemployees,CourseId,StartDate,EndDate,Rating")] ECourse eCourse)
        {
            if (id != eCourse.IdemployeesCourses)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ECourseExists(eCourse.IdemployeesCourses))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", eCourse.CourseId);
            ViewData["Idemployees"] = new SelectList(_context.Employees, "IdEmployees", "Name", eCourse.Idemployees);
            return View(eCourse);
        }

        // GET: ECourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ECourses == null)
            {
                return NotFound();
            }

            var eCourse = await _context.ECourses
                .Include(e => e.Course)
                .Include(e => e.IdemployeesNavigation)
                .FirstOrDefaultAsync(m => m.IdemployeesCourses == id);
            if (eCourse == null)
            {
                return NotFound();
            }

            return View(eCourse);
        }

        // POST: ECourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ECourses == null)
            {
                return Problem("Entity set 'Teat2Context.ECourses'  is null.");
            }
            var eCourse = await _context.ECourses.FindAsync(id);
            if (eCourse != null)
            {
                _context.ECourses.Remove(eCourse);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ECourseExists(int id)
        {
          return _context.ECourses.Any(e => e.IdemployeesCourses == id);
        }
    }
}
