using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LearningManagementSystem.Data;
using LearningManagementSystem.Models;

namespace LearningManagementSystem.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly Teat2Context _context;
        EmployeesViewModel _employeesViewModel = new EmployeesViewModel();

       
        public EmployeesController(Teat2Context context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var s = await _context.Employees.Include(c=>c.Rank).Include(x=>x.JopTypeNavigation).ToListAsync();
            return _context.Employees != null ?
                          View(await _context.Employees.ToListAsync()) :
                          Problem("Entity set 'Teat2Context.employees'  is null.");
            //_employeesViewModel.listemployees = await _context.Employees.ToListAsync();
            // return View(_employeesViewModel);
        }
        public async Task<IActionResult> AuditIndex()
        {
            var s = await _context.Employees.Where(m=>m.Enterd==true&&m.Audited==null).Include(c => c.Rank).Include(x => x.JopTypeNavigation).ToListAsync();
            return _context.Employees != null ?
                          View(await _context.Employees.ToListAsync()) :
                          Problem("Entity set 'Teat2Context.employees'  is null.");
            //_employeesViewModel.listemployees = await _context.Employees.ToListAsync();
            // return View(_employeesViewModel);
        }


        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.JopTypeNavigation)
                .Include(e => e.Rank)
                .FirstOrDefaultAsync(m => m.IdEmployees == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["JopType"] = new SelectList(_context.Jops, "Idjops", "JopName");
            ViewData["RankId"] = new SelectList(_context.Ranks, "Idrank", "Rankname");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Employee employee)
        {
            if (ModelState.IsValid)
            {
                //Employee e=new Employee();
                //e.Name = employee.Name;
                //e.Identitynumber = employee.Identitynumber;
                //e.Employeenumber = employee.Employeenumber;
                //e.Gender= (int)employee.GenderType;
                //e.JopType = employee.jobId;
                //e.RankId = employee.RankId;
                employee.Enterd = true;
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JopType"] = new SelectList(_context.Jops, "Idjops", "JopName", employee.JopType);
            ViewData["RankId"] = new SelectList(_context.Ranks, "Idrank", "Rankname", employee.RankId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["JopType"] = new SelectList(_context.Jops, "Idjops", "JopName", employee.JopType);
            ViewData["RankId"] = new SelectList(_context.Ranks, "Idrank", "Rankname", employee.RankId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Employee employee)
        {
            if (id != employee.IdEmployees)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.IdEmployees))
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
            ViewData["JopType"] = new SelectList(_context.Jops, "Idjops", "JopName", employee.JopType);
            ViewData["RankId"] = new SelectList(_context.Ranks, "Idrank", "Rankname", employee.RankId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.JopTypeNavigation)
                .Include(e => e.Rank)
                .FirstOrDefaultAsync(m => m.IdEmployees == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'Teat2Context.Employees'  is null.");
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
          return (_context.Employees?.Any(e => e.IdEmployees == id)).GetValueOrDefault();
        }
    }
}
