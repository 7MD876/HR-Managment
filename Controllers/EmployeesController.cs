using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LearningManagementSystem.Data;
using LearningManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace LearningManagementSystem.Controllers
{
    [Authorize("Authorization")]
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

            var s = await _context.Employees.Include(c => c.Rank).Include(x => x.JopTypeNavigation).ToListAsync();
            return _context.Employees != null ?
                          View(await _context.Employees.ToListAsync()) :
                          Problem("Entity set 'Teat2Context.employees'  is null.");
           
        }
        public async Task<IActionResult> AuditIndex()
        {
            var s = await _context.Employees.Where(m => m.Enterd == true).Include(c => c.Rank).Include(x => x.JopTypeNavigation).ToListAsync();
            return _context.Employees != null ?
                          View(s) :
                          Problem("Entity set 'Teat2Context.employees'  is null.");
            
        }
        public async Task<IActionResult> ApproveIndex()
        {
            var s = await _context.Employees.Where(m => m.Enterd == true && m.Audited == true ).Include(c => c.Rank).Include(x => x.JopTypeNavigation).ToListAsync();
            return _context.Employees != null ?
                          View(s) :
                          Problem("Entity set 'Teat2Context.employees'  is null.");
            
        }
        //public async Task<IActionResult> FinishIndex()
        //{
        //    var s = await _context.Employees.Where(m => m.Enterd == true && m.Approved == true && m.Finished == null).Include(c => c.Rank).Include(x => x.JopTypeNavigation).ToListAsync();
        //    return _context.Employees != null ?
        //                  View(s) :
        //                  Problem("Entity set 'Teat2Context.employees'  is null.");

        //}


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
                .Include(e => e.ECourses).ThenInclude(c => c.Course)
                .Include(e => e.EMedels).ThenInclude(c => c.Medals)
                .Include(e => e.ETransfers).ThenInclude(c => c.Transfer)
                .Include(e => e.ETransfers).ThenInclude(c => c.FromUnitNavigation)
                .Include(e => e.ETransfers).ThenInclude(c => c.ToUnitNavigation)
                .Include(e => e.Unit)
                .FirstOrDefaultAsync(m => m.IdEmployees == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        public async Task<IActionResult> EmployeeFile(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.JopTypeNavigation)
                .Include(e => e.Rank)
                .Include(e => e.ECourses).ThenInclude(c => c.Course)
                .Include(e => e.EMedels).ThenInclude(c => c.Medals)
                .Include(e => e.ETransfers).ThenInclude(c => c.Transfer)
                .Include(e => e.ETransfers).ThenInclude(c => c.FromUnitNavigation)
                .Include(e => e.ETransfers).ThenInclude(c => c.ToUnitNavigation)
                .Include(e => e.Unit)
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
            ViewData["UnitsId"] = new SelectList(_context.Units, "UnitId", "UnitName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid && (!EmployeeExists(employee.Identitynumber)))
            {


                _context.Add(employee);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            ModelState.AddModelError("", " رقم الهوية الوطنية مضافة مسبقاً");
            ViewData["JopType"] = new SelectList(_context.Jops, "Idjops", "JopName", employee.JopType);
            ViewData["RankId"] = new SelectList(_context.Ranks, "Idrank", "Rankname", employee.RankId);
            ViewData["UnitsId"] = new SelectList(_context.Units, "UnitId", "UnitName");
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
            ViewData["UnitsId"] = new SelectList(_context.Units, "UnitId", "UnitName");
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
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
                    if (!EmployeeExists(employee.Identitynumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                if (employee.Enterd != true && employee.Audited != true)
                {
                    return RedirectToAction("Index", "Employees");
                }
                else if (employee.Enterd == true && employee.Audited!=true && employee.Approved!=true)
                {
                    return RedirectToAction("AuditIndex", "Employees");
                }
                else
                {
                    return RedirectToAction("ApproveIndex", "Employees");
                }
            }
            ViewData["JopType"] = new SelectList(_context.Jops, "Idjops", "JopName", employee.JopType);
            ViewData["RankId"] = new SelectList(_context.Ranks, "Idrank", "Rankname", employee.RankId);
            ViewData["UnitsId"] = new SelectList(_context.Units, "UnitId", "UnitName");

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
            try
            {

                var employee = await _context.Employees.Where(c=>c.IdEmployees==id).Include(c=>c.ECourses).Include(c=>c.ETransfers).Include(c=>c.EMedels).Include(c=>c.EJobs).FirstOrDefaultAsync();
                var status = 1;
                if (employee != null)
                {
                    if (employee.Enterd != true && employee.Audited != true && employee.Approved != true)
                    {
                        status = 1;
                    }
                    else if (employee.Enterd == true && employee.Audited != true && employee.Approved != true)
                    {
                        status = 2;
                    }
                    else
                    {
                        status = 3;
                    }
                    _context.ECourses.RemoveRange(employee.ECourses);
                    _context.ETransfers.RemoveRange(employee.ETransfers);
                    _context.EMedels.RemoveRange(employee.EMedels);
                    _context.EJobs.RemoveRange(employee.EJobs);
                    _context.Employees.Remove(employee);
                }

                await _context.SaveChangesAsync();

                if (status == 1)
                {
                    return RedirectToAction("Index", "Employees");
                }
                else if (status == 2)
                {
                    return RedirectToAction("AuditIndex", "Employees");
                }
                else 
                {
                    return RedirectToAction("ApproveIndex", "Employees");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "احذف جميع البيانات بداخل الموظف");
                return RedirectToAction("Delete",new {id});
            }
                    }

        private bool EmployeeExists(int id)
        {
            return (_context.Employees?.Any(e => e.Identitynumber == id)).GetValueOrDefault();
        }

        public JsonResult sendToAudit(int id)
        {

            var em = _context.Employees.Find(id);
            if (em != null)
            {
                em.Enterd = true;
                _context.Update(em);
                _context.SaveChanges();
                return Json(true);

            }
            else
            {
                return Json(false);
            }

        }
        public JsonResult sendToApprove(int id)
        {

            var em = _context.Employees.Find(id);
            if (em != null)
            {
                em.Enterd = true;
                em.Audited = true; 
                _context.Update(em);
                _context.SaveChanges();
                return Json(true);

            }
            else
            {
                return Json(false);
            }

        }
        public JsonResult sendToFinish(int id)
        {
            
            var em = _context.Employees.Find(id);
            if (em != null)
            {
                em.Enterd = true;
                em.Audited= true;
                em.Approved = true; 
                _context.Update(em);
                _context.SaveChanges();
                return Json(true);

            }
            else
            {
                return Json(false);
            }

        }
        public JsonResult BackToEntry(int id)
        {
            var em = _context.Employees.Find(id);
            if (em != null)
            {
                em.Enterd = false;
                em.Audited = false;
                em.Approved = false;
                _context.Update(em);
                _context.SaveChanges();
                return Json(true);

            }
            else
            {
                return Json(false);
            }
        }
        public JsonResult BackToAudit(int id)
        {
            var em = _context.Employees.Find(id);
            if (em != null)
            {
                em.Audited = false;
                em.Approved = false;
                _context.Update(em);
                _context.SaveChanges();
                return Json(true);

            }
            else
            {
                return Json(false);
            }
        }
    }
}
