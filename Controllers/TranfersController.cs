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
    public class TranfersController : Controller
    {
        private readonly Teat2Context _context;

        public TranfersController(Teat2Context context)
        {
            _context = context;
        }

        // GET: Tranfers
        public async Task<IActionResult> Index()
        {
              return View(await _context.Tranfers.ToListAsync());
        }

        // GET: Tranfers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tranfers == null)
            {
                return NotFound();
            }

            var tranfer = await _context.Tranfers
                .FirstOrDefaultAsync(m => m.TransferId == id);
            if (tranfer == null)
            {
                return NotFound();
            }

            return View(tranfer);
        }

        // GET: Tranfers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tranfers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransferId,TransferName")] Tranfer tranfer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tranfer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tranfer);
        }

        // GET: Tranfers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tranfers == null)
            {
                return NotFound();
            }

            var tranfer = await _context.Tranfers.FindAsync(id);
            if (tranfer == null)
            {
                return NotFound();
            }
            return View(tranfer);
        }

        // POST: Tranfers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransferId,TransferName")] Tranfer tranfer)
        {
            if (id != tranfer.TransferId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tranfer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TranferExists(tranfer.TransferId))
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
            return View(tranfer);
        }

        // GET: Tranfers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tranfers == null)
            {
                return NotFound();
            }

            var tranfer = await _context.Tranfers
                .FirstOrDefaultAsync(m => m.TransferId == id);
            if (tranfer == null)
            {
                return NotFound();
            }

            return View(tranfer);
        }

        // POST: Tranfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tranfers == null)
            {
                return Problem("Entity set 'Teat2Context.Tranfers'  is null.");
            }
            var tranfer = await _context.Tranfers.FindAsync(id);
            if (tranfer != null)
            {
                _context.Tranfers.Remove(tranfer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TranferExists(int id)
        {
          return _context.Tranfers.Any(e => e.TransferId == id);
        }
    }
}
