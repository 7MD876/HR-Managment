using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LearningManagementSystem.Data;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;

namespace LearningManagementSystem.Controllers
{
    [Authorize("Authorization")]
    public class ETransfersController : Controller
    {
        private readonly Teat2Context _context;

        public ETransfersController(Teat2Context context)
        {
            _context = context;
        }

        // GET: ETransfers
        public async Task<IActionResult> Index()
        {
            var teat2Context = _context.ETransfers
                .Include(e => e.IdEmployeesNavigation)
                .Include(e => e.Transfer)
                .Include(s=> s.FromUnitNavigation)
                .Include(a=> a.ToUnitNavigation);
            return View(await teat2Context.ToListAsync());
        }

        // GET: ETransfers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ETransfers == null)
            {
                return NotFound();
            }

            var eTransfer = await _context.ETransfers
                .Include(e => e.IdEmployeesNavigation)
                .Include(e => e.Transfer)
                .FirstOrDefaultAsync(m => m.IdTransfer == id);
            if (eTransfer == null)
            {
                return NotFound();
            }

            return View(eTransfer);
        }

        // GET: ETransfers/Create
        public IActionResult Create(int id)
        {
            ViewBag.Id = id;
            ViewData["IdTransfer"] = new SelectList(_context.Tranfers, "TransferId", "TransferName");
            ViewBag.EmployeeName = _context.Employees.Find(id).Name;
            ViewData["UnitsId"] = new SelectList(_context.Units,"UnitId", "UnitName");
            return View();

        }

        // POST: ETransfers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ETransfer eTransfer)
        {
            if (ModelState.IsValid)
            {
                eTransfer.IdEmployees = Convert.ToInt32(TempData["idEmp"]);
                _context.Add(eTransfer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Employees");
            }
            ViewData["IdEmployees"] = new SelectList(_context.Employees, "IdEmployees", "IdEmployees", eTransfer.IdEmployees);
            ViewData["IdTransfer"] = new SelectList(_context.Tranfers, "TransferId", "TransferId", eTransfer.IdTransfer);
            return View(eTransfer);
        }

        // GET: ETransfers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            

            if (id == null || _context.ETransfers == null)

            {
                return NotFound();
            }

            var eTransfer = await _context.ETransfers.FindAsync(id);

            if (eTransfer == null)

            {
                return NotFound();
            }
            ViewData["ToUnit"] = new SelectList(_context.Units, "UnitId", "UnitName",eTransfer.ToUnit);
            ViewData["FromUnit"] = new SelectList(_context.Units, "UnitId", "UnitName", eTransfer.FromUnit);
            ViewData["IdEmployees"] = new SelectList(_context.Employees, "IdEmployees", "IdEmployees", eTransfer.IdEmployees);
            ViewBag.Id = eTransfer.IdEmployees;
            ViewBag.EmployeeName = _context.Employees.Find(eTransfer.IdEmployees).Name;
            ViewData["IdTransfer"] = new SelectList(_context.Tranfers, "TransferId", "TransferName", eTransfer.IdTransfer);
            return View(eTransfer);
        }

        // POST: ETransfers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,ETransfer eTransfer)
        {
            if (id != eTransfer.IdTransfer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    id = eTransfer.IdEmployees;
                    _context.Update(eTransfer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ETransferExists(eTransfer.IdTransfer))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "employees", new { id });

                //var s = await _context.Employees.FindAsync(eTransfer.IdEmployees);
                //if (s .Enterd !=true && s  .Audited != true&& s .Approved != true)
                //{
                //    return RedirectToAction("Index","Employees");
                //}else if(s.Enterd == true && s.Audited != true && s.Approved != true)
                //{
                //    return RedirectToAction("AuditIndex", "Employees");
                //}
                //else
                //{
                //    return RedirectToAction("ApproveIndex", "Employees");
                //}
            }
            ViewData["IdEmployees"] = new SelectList(_context.Employees, "IdEmployees", "IdEmployees", eTransfer.IdEmployees);
            ViewData["IdTransfer"] = new SelectList(_context.Tranfers, "TransferId", "TransferId", eTransfer.IdTransfer);
            return View(eTransfer);
        }

        // GET: ETransfers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ETransfers == null)
            {
                return NotFound();
            }

            var eTransfer = await _context.ETransfers
                .Include(e => e.IdEmployeesNavigation)
                .Include(e => e.Transfer)
                .FirstOrDefaultAsync(m => m.IdTransfer == id);
            if (eTransfer == null)
            {
                return NotFound();
            }

            return View(eTransfer);
        }

        // POST: ETransfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ETransfers == null)
            {
                return Problem("Entity set 'Teat2Context.ETransfers'  is null.");
            }
            var eTransfer = await _context.ETransfers.FindAsync(id);
            if (eTransfer != null)
            {
                id = eTransfer.IdEmployees;
                _context.ETransfers.Remove(eTransfer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "employees", new { id }); ;
        }

        private bool ETransferExists(int id)
        {
          return _context.ETransfers.Any(e => e.IdTransfer == id);
        }
    }
}
