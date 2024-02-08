using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LearningManagementSystem.Data;
using System.Security.Cryptography;
using LearningManagementSystem.Models;
using LearningManagementSystem.Utilities;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace LearningManagementSystem.Controllers
{
    [Authorize("Authorization")]
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
        public IActionResult Create(int id)
        {
            ViewBag.Id = id;
            ViewData["Idmedels"] = new SelectList(_context.Medels, "Idmedels", "MedelsName" );
            ViewBag.EmployeeName = _context.Employees.Find(id).Name;

            return View();

            //ViewBag.Id = id;
            //ViewData["Idemployees"] = new SelectList(_context.Employees, "IdEmployees", "IdEmployees");
            //ViewBag.EmployeeName = _context.Employees.Find(id).Name;
            //ViewData["MedalsId"] = new SelectList(_context.Medels, "Idmedels", "Idmedels");
            //return View();
        }

        // POST: EMedels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdeMedals,MedalsId,DateMedals,Idemployees")] EMedel eMedal)
        {
            if (ModelState.IsValid)
            {
                eMedal.Idemployees = Convert.ToInt32(TempData["idEmp"]);
                var i = _context.EMedels.Where(s => s.Idemployees == eMedal.Idemployees && s.MedalsId== eMedal.MedalsId).FirstOrDefault();
                if
                    (i != null)
                {
                    
                    ModelState.AddModelError("", "الوسام أو النوط مضاف مسبقاٌ");
                    ViewData["Idmedels"] = new SelectList(_context.Medels, "Idmedels", "MedelsName", eMedal.MedalsId);
                    ViewData["Idemployees"] = new SelectList(_context.Employees, "IdEmployees", "Name", eMedal.Idemployees);
                    ViewBag.Id = eMedal.Idemployees;
                    return View(eMedal);
                }
                _context.Add(eMedal);
                await _context.SaveChangesAsync();
                return RedirectToAction("UploadEMedalsFiles", new { eMedal.IdeMedals, eMedal.Idemployees });
            }
            ViewData["Idemployees"] = new SelectList(_context.Employees, "IdEmployees", "IdEmployees", eMedal.Idemployees);
            ViewBag.Id = eMedal.Idemployees;
            ViewData["Idmedels"] = new SelectList(_context.Medels, "Idmedels", "MedelsName", eMedal.MedalsId);
            return View(eMedal);
        }

        // GET: EMedels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EMedels == null)
            {
                return NotFound();
            }

            var eMedal = await _context.EMedels.FindAsync(id);
            if (eMedal == null)
            {
                return NotFound();
            }
            ViewData["MedalsId"] = new SelectList(_context.Medels, "Idmedels", "MedelsName", eMedal.MedalsId);
            ViewBag.Id = eMedal.Idemployees;
            ViewBag.EmployeeName = _context.Employees.Find(eMedal.Idemployees).Name;
            return View(eMedal);
        }

        // POST: EMedels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, EMedel eMedal)
        {
            if (id != eMedal.IdeMedals)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    eMedal.Idemployees = Convert.ToInt32(TempData["idEmp"]);
                    _context.Update(eMedal);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("EditUploadEMedalsFiles", new { eMedal.IdeMedals, eMedal.Idemployees });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EMedelExists(eMedal.IdeMedals))
                    {
                        return NotFound();
                    }
                    else
                    {
                    }
                }
            }
            ViewBag.Id = eMedal.Idemployees;
            ViewData["MedalsId"] = new SelectList(_context.Medels, "Idmedels", "MedelsName", eMedal.MedalsId);
            ViewData["Idemployees"] = new SelectList(_context.Employees, "IdEmployees", "Name", eMedal.Idemployees);
            return View(eMedal);
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
                id = eMedel.Idemployees;
                _context.EMedels.Remove(eMedel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "employees", new { id });
        }

        private bool EMedelExists(int id)
        {
          return _context.EMedels.Any(e => e.IdeMedals == id);
        }
        public IActionResult UploadEMedalsFiles(int IdeMedals, int Idemployees)
        {
            MedelsModel medels  = new MedelsModel();
            medels.IdeMedals = IdeMedals;
            medels.empID = Idemployees;
            var addedMedals = _context.EMedels.Where(c => c.Idemployees == Idemployees && c.IdeMedals == IdeMedals).Include(c => c.IdemployeesNavigation).FirstOrDefault();
            if (addedMedals != null)
            {
                medels.MedalsID = addedMedals.MedalsId;
                medels.IdentityNumber = addedMedals.IdemployeesNavigation.Identitynumber;
            }
            return View(medels);
        }
        public IActionResult EditUploadEMedalsFiles(int IdeMedals, int Idemployees)
        {
            
            MedelsModel medels = new MedelsModel();
            medels.IdeMedals = IdeMedals;
            medels.empID = Idemployees;
            
            var addedMedals = _context.EMedels.Where(c => c.Idemployees == Idemployees && c.IdeMedals == IdeMedals).Include(c => c.IdemployeesNavigation).FirstOrDefault();
            if (addedMedals != null)
            {
                medels.MedalsID = addedMedals.MedalsId;
                medels.IdentityNumber = addedMedals.IdemployeesNavigation.Identitynumber;
            }

            return View(medels);
        }

        public async Task UploadFiles(List<IFormFile> files, MedelsModel medels)
        {
            var userLoged = _context.AspNetUsers.Where(c => c.UserName == User.Identity.Name).FirstOrDefault().Id;
            foreach (var file in files)
            {
                //get uploaded file name
                var fileName = file.TempFileName();

                if (file.Length > 0)
                {
                    var path = Environment.CurrentDirectory + "\\wwwroot\\Uploads\\" + medels.IdentityNumber + "\\Medals\\" + medels.IdeMedals;
                    var dirIsExist = Directory.Exists(path);
                    if (!dirIsExist)
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (var stream = new FileStream(path + fileName, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
        }
        public JsonResult OnGetListFolderContents(int IdeMedals, int IdentityNumber)
        {
            var folderPath = Environment.CurrentDirectory + "\\wwwroot\\Uploads\\" + IdentityNumber + "\\Medals\\" + IdeMedals;

            if (!Directory.Exists(folderPath))
                return new JsonResult("Folder not exists!") { StatusCode = (int)HttpStatusCode.NotFound };

            var folderItems = Directory.GetFiles(folderPath);

            if (folderItems.Length == 0)
                return new JsonResult("Folder is empty!") { StatusCode = (int)HttpStatusCode.NoContent };

            var galleryItems = new List<FileItem>();

            foreach (var file in folderItems)
            {
                var fileInfo = new FileInfo(file);
                galleryItems.Add(new FileItem
                {
                    Name = fileInfo.Name,
                    FilePath = $"https://localhost:44365/Uploads/{IdentityNumber}/Medals/{IdeMedals}/{fileInfo.Name}",
                    FileSize = fileInfo.Length
                });
            }

            return new JsonResult(galleryItems) { StatusCode = 200 };
        }
        public JsonResult OnGetDeleteFile(string file, int IdeMedals, int IdentityNumber)
        {
            var filePath = Environment.CurrentDirectory + "\\wwwroot\\Uploads\\" + IdentityNumber + "\\Medals\\" + IdeMedals + "\\" + file;

            try
            {
                System.IO.File.Delete(filePath);
            }
            catch
            {
                return new JsonResult(false) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }

            return new JsonResult(true) { StatusCode = (int)HttpStatusCode.OK };
        }
    }
    
}

