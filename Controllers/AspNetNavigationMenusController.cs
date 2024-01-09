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
    public class AspNetNavigationMenusController : Controller
    {
        private readonly Teat2Context _context;

        public AspNetNavigationMenusController(Teat2Context context)
        {
            _context = context;
        }

        // GET: AspNetNavigationMenus
        public async Task<IActionResult> Index()
        {
            var teat2Context = _context.AspNetNavigationMenus.Include(a => a.ParentMenu);
            return View(await teat2Context.ToListAsync());
        }

        // GET: AspNetNavigationMenus/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.AspNetNavigationMenus == null)
            {
                return NotFound();
            }

            var aspNetNavigationMenu = await _context.AspNetNavigationMenus
                .Include(a => a.ParentMenu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetNavigationMenu == null)
            {
                return NotFound();
            }

            return View(aspNetNavigationMenu);
        }

        // GET: AspNetNavigationMenus/Create
        public IActionResult Create()
        {
            ViewData["ParentMenuId"] = new SelectList(_context.AspNetNavigationMenus, "Id", "Name");
            return View();
        }

        // POST: AspNetNavigationMenus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AspNetNavigationMenu aspNetNavigationMenu)
        {
            if ((!ModelState.IsValid&&aspNetNavigationMenu.ParentMenuId==null)||ModelState.IsValid)
            {
                aspNetNavigationMenu.Id = Guid.NewGuid();
                _context.Add(aspNetNavigationMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentMenuId"] = new SelectList(_context.AspNetNavigationMenus, "Id", "Name", aspNetNavigationMenu.ParentMenuId);
            return View(aspNetNavigationMenu);
        }

        // GET: AspNetNavigationMenus/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.AspNetNavigationMenus == null)
            {
                return NotFound();
            }

            var aspNetNavigationMenu = await _context.AspNetNavigationMenus.FindAsync(id);
            if (aspNetNavigationMenu == null)
            {
                return NotFound();
            }
            ViewData["ParentMenuId"] = new SelectList(_context.AspNetNavigationMenus, "Id", "Name", aspNetNavigationMenu.ParentMenuId);
            return View(aspNetNavigationMenu);
        }

        // POST: AspNetNavigationMenus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,ParentMenuId,Area,ControllerName,ActionName,IsExternal,ExternalUrl,DisplayOrder,Visible")] AspNetNavigationMenu aspNetNavigationMenu)
        {
            if (id != aspNetNavigationMenu.Id)
            {
                return NotFound();
            }

            if ((!ModelState.IsValid && aspNetNavigationMenu.ParentMenuId == null) || ModelState.IsValid)
            {
                try
                {
                    _context.Update(aspNetNavigationMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspNetNavigationMenuExists(aspNetNavigationMenu.Id))
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
            ViewData["ParentMenuId"] = new SelectList(_context.AspNetNavigationMenus, "Id", "Name", aspNetNavigationMenu.ParentMenuId);
            return View(aspNetNavigationMenu);
        }

        // GET: AspNetNavigationMenus/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.AspNetNavigationMenus == null)
            {
                return NotFound();
            }

            var aspNetNavigationMenu = await _context.AspNetNavigationMenus
                .Include(a => a.ParentMenu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetNavigationMenu == null)
            {
                return NotFound();
            }

            return View(aspNetNavigationMenu);
        }

        // POST: AspNetNavigationMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.AspNetNavigationMenus == null)
            {
                return Problem("Entity set 'Teat2Context.AspNetNavigationMenus'  is null.");
            }
            var aspNetNavigationMenu = await _context.AspNetNavigationMenus.FindAsync(id);
            if (aspNetNavigationMenu != null)
            {
                _context.AspNetNavigationMenus.Remove(aspNetNavigationMenu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AspNetNavigationMenuExists(Guid id)
        {
          return _context.AspNetNavigationMenus.Any(e => e.Id == id);
        }
    }
}
