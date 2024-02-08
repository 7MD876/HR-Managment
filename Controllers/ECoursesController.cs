using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LearningManagementSystem.Data;
using SQLitePCL;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using LearningManagementSystem.Utilities;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using LearningManagementSystem.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;

namespace LearningManagementSystem.Controllers
{
    [Authorize("Authorization")]
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
        public IActionResult Create(int id)
        {
            
            ViewBag.Id = id;
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName");
            ViewBag.EmployeeName = _context.Employees.Find(id).Name;
           
            return View();

        }

        // POST: ECourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ECourse eCourse)
        {
            if (ModelState.IsValid)
            {
                eCourse.Idemployees = Convert.ToInt32(TempData["idEmp"]);
                var i = _context.ECourses.Where(s => s.Idemployees == eCourse.Idemployees && s.CourseId == eCourse.CourseId).FirstOrDefault();
                if
                    (i != null) 
                {
                    ViewBag.Id = eCourse.Idemployees;
                    ModelState.AddModelError("", "الدورة مضافة مسبقا");
                    ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", eCourse.CourseId);
                    ViewData["Idemployees"] = new SelectList(_context.Employees, "IdEmployees", "Name", eCourse.Idemployees);
                    return View(eCourse);
                }
                _context.Add(eCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction("UploadECoursesFiles",new { eCourse.CourseId, eCourse.Idemployees});
            }
            ViewBag.Id = eCourse.Idemployees;
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
            ViewBag.Id = eCourse.Idemployees;
            ViewBag.EmployeeName = _context.Employees.Find(eCourse.Idemployees).Name;
            return View(eCourse);
        }

        // POST: ECourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ECourse eCourse)
        {
            if (id != eCourse.IdemployeesCourses)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    eCourse.Idemployees = Convert.ToInt32(TempData["idEmp"]);
                    _context.Update(eCourse);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("EditUploadECoursesFiles", new { eCourse.CourseId, eCourse.Idemployees });                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ECourseExists(eCourse.IdemployeesCourses))
                    {
                        return NotFound();
                    }
                    else
                    {
                        return RedirectToAction("Details","employees", new { eCourse.Idemployees });
                    }
                }
            }
            ViewBag.Id = eCourse.Idemployees;
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
        public async Task<IActionResult>  DeleteConfirmed(int id)
       
        {
            
            if (_context.ECourses == null)
            {
                return Problem("Entity set 'Teat2Context.ECourses'  is null.");
            }
            var eCourse = await _context.ECourses.FindAsync(id);
           
            if (eCourse != null)
            {
                id = eCourse.Idemployees;
                _context.ECourses.Remove(eCourse);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Details","employees", new {id});
        }


        private bool ECourseExists(int id)
        {
          return _context.ECourses.Any(e => e.IdemployeesCourses == id);
        }
        public IActionResult UploadECoursesFiles(int courseID, int Idemployees)
        {
            CoursesModel course = new CoursesModel();
            course.courseID = courseID;
            course.empID = Idemployees;

            var addedCourse = _context.ECourses.Where(c => c.Idemployees == Idemployees && c.CourseId == courseID).Include(c=>c.IdemployeesNavigation).FirstOrDefault();
            if (addedCourse != null)
            {
                course.IDEmployeeCourses = addedCourse.IdemployeesCourses;
                course.IdentityNumber = addedCourse.IdemployeesNavigation.Identitynumber;
                if (addedCourse.IdemployeesNavigation.Enterd==true&& addedCourse.IdemployeesNavigation.Audited!=true&& addedCourse.IdemployeesNavigation.Approved!=true)
                {
                    course.status = 2;
                }
                else if(addedCourse.IdemployeesNavigation.Enterd==true && addedCourse.IdemployeesNavigation.Audited == true&& addedCourse.IdemployeesNavigation.Approved != true)
                {
                    course.status = 3;
                }
                else
                {
                    course.status = 1;
                }
            }
            return View(course);
        }
        public IActionResult EditUploadECoursesFiles(int courseID, int Idemployees)
        {
            CoursesModel course = new CoursesModel();
            course.courseID = courseID;
            course.empID = Idemployees;

            var addedCourse = _context.ECourses.Where(c => c.Idemployees == Idemployees && c.CourseId == courseID).Include(c => c.IdemployeesNavigation).FirstOrDefault();
            if (addedCourse != null)
            {
                course.IDEmployeeCourses = addedCourse.IdemployeesCourses;
                course.IdentityNumber = addedCourse.IdemployeesNavigation.Identitynumber;
                if (addedCourse.IdemployeesNavigation.Enterd == true && addedCourse.IdemployeesNavigation.Audited != true && addedCourse.IdemployeesNavigation.Approved != true)
                {
                    course.status = 2;
                }
                else if (addedCourse.IdemployeesNavigation.Enterd == true && addedCourse.IdemployeesNavigation.Audited == true && addedCourse.IdemployeesNavigation.Approved != true)
                {
                    course.status = 3;
                }
                else
                {
                    course.status = 1;
                }
            }
            return View(course);
        }

        public async Task UploadFiles(List<IFormFile> files, CoursesModel course)
        {
            var userLoged = _context.AspNetUsers.Where(c => c.UserName == User.Identity.Name).FirstOrDefault().Id;
            foreach (var file in files)
            {
                //get uploaded file name
                var fileName = file.TempFileName();

                if (file.Length > 0)
                {
                    var path = Environment.CurrentDirectory + "\\wwwroot\\Uploads\\"+ course.IdentityNumber+ "\\CoursesCertificates\\" + course.courseID;
                    var dirIsExist = Directory.Exists(path);
                    if (!dirIsExist)
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (var stream = new FileStream(path+fileName, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
        }
        public JsonResult OnGetListFolderContents(int courseID, int IdentityNumber)
        {
            var folderPath = Environment.CurrentDirectory + "\\wwwroot\\Uploads\\" + IdentityNumber+ "\\CoursesCertificates\\" + courseID;

            if (!Directory.Exists(folderPath))
                return new JsonResult("Folder not exists!") { StatusCode = (int)HttpStatusCode.NotFound };

            var folderItems =  Directory.GetFiles(folderPath);

            if (folderItems.Length == 0)
                return new JsonResult("Folder is empty!") { StatusCode = (int)HttpStatusCode.NoContent };

            var galleryItems = new List<FileItem>();

            foreach (var file in folderItems)
            {
                var fileInfo = new FileInfo(file);
                galleryItems.Add(new FileItem
                {
                    Name = fileInfo.Name,
                    FilePath = $"https://localhost:44365/Uploads/{IdentityNumber}/CoursesCertificates/{courseID}/{fileInfo.Name}",
                    FileSize = fileInfo.Length
                });
            }

            return new JsonResult(galleryItems) { StatusCode = 200 };
        }
        public JsonResult OnGetDeleteFile(string file, int courseID, int IdentityNumber)
        {
            var filePath = Environment.CurrentDirectory + "\\wwwroot\\Uploads\\"+IdentityNumber+ "\\CoursesCertificates\\" + courseID+"\\"+file;

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
    public class FileItem
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public double FileSize { get; set; }
    }
}
