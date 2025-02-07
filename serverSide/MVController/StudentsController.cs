using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using serverSide.Data;
using serverSide.Models;
using serverSide.ViewModel;

namespace serverSide.MVController
{
    public class StudentsController : Controller
    {
        private readonly CDKDbContext _context;

        public StudentsController(CDKDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var cDKDbContext = _context.Students.Include(s => s.Department).Include(s => s.Section);
            return View(await cDKDbContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Department)
                .Include(s => s.Section)
                .FirstOrDefaultAsync(m => m.StudentId == id);

            var getDepartmentById = _context.Department.Find(student!.DepartmentId)!.DepartmentId;

            var viewData = new StudentCourseView
            {
                ListOfCourses = _context.Courses.Where(c => c.DepartmentId == getDepartmentById).ToList(),
                Student = student
            };


            return View(viewData);
        }
        // GET: Students/Create


        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentId", student.DepartmentId);
            ViewData["SectionId"] = new SelectList(_context.Set<Section>(), "SectionId", "SectionId", student.SectionId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StudentId,Firstname,Middlename,Lastname,Status,SectionId,DepartmentId")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentId", student.DepartmentId);
            ViewData["SectionId"] = new SelectList(_context.Set<Section>(), "SectionId", "SectionId", student.SectionId);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(string? id, int departmentId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Department)
                .Include(s => s.Section)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id, int departmentId)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Departments");
        }

        private bool StudentExists(string id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }

    }
}
