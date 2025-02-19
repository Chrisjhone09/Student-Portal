using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using serverSide.CommonUtilities;
using serverSide.Data;
using serverSide.Models;
using serverSide.ViewModel;

namespace serverSide.MVController
{
    public class DepartmentsController : Controller
    {
        private readonly CDKDbContext _context;

        public DepartmentsController(CDKDbContext context)
        {
            _context = context;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Department.ToListAsync());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Department
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }
            var modelData = new StudentCourseView
            {
                ListOfStudent = _context.Students.Where(s => s.DepartmentId == id).ToList(),
                ListOfCourses = _context.Courses.Where(s => s.DepartmentId == id).ToList(),
                Department = department,
                ListOfInstructors = _context.Instructors.Where(i => i.InstructorId == id).ToList(),
                DepartmentId = id
            };
            return View(modelData);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentName,StudentCount")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Department.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Department.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentId,DepartmentName,StudentCount")] Department department)
        {
            if (id != department.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _context.Update(department);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Department
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }



            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await _context.Department.FindAsync(id);
            if (department != null)
            {
                _context.Department.Remove(department);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult AddStudent(StudentCourseView model)
        {
            var department = new Student()
            {
                StudentId = null!,
                Firstname = null!,
                Middlename = null!,
                Lastname = null!,
                ListOfDepatment = _context.Department.ToList(),
                DepartmentId = model.DepartmentId,
                Department = _context.Department.Find(model.DepartmentId)
            };
            return View(department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStudent([Bind("StudentId,Firstname,Middlename,Lastname,Status,SectionId,DepartmentName")] Student student)
        {
            if (ModelState.IsValid)
            {
                int departmentId = _context.Department.FirstOrDefault(d => d.DepartmentName == student!.DepartmentName)!.DepartmentId;
                var section = _context.Section.FirstOrDefault(s => s.StudentCount != 40 && s.DepartmentId == departmentId);
                if (section == null)
                {
                    SharedFunction method = new SharedFunction(_context);
                    var newSection = new Section
                    {
                        SectionName = method.GenerateSectionName(departmentId, student!.Year),
                        StudentCount = 0,
                        DepartmentId = departmentId
                    };
                    _context.Section.Add(newSection);
                    _context.SaveChanges();

                    var getSection = _context.Section.FirstOrDefault(s => s.DepartmentId == departmentId && s.StudentCount != 40);

                    var studentModel = new Student
                    {
                        StudentId = student.StudentId,
                        Firstname = student.Firstname,
                        Middlename = student.Middlename,
                        Lastname = student.Lastname,
                        DepartmentId = departmentId,
                        SectionId = getSection!.SectionId
                    };
                    var getDepartment = _context.Department.FirstOrDefault(d => d.DepartmentId == studentModel.DepartmentId);
                    getDepartment!.StudentCount++;
                    _context.Department.Update(getDepartment);
                    _context.Add(studentModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Departments");
                }
                else
                {
                    var stud = new Student
                    {
                        StudentId = student.StudentId,
                        Firstname = student.Firstname,
                        Middlename = student.Middlename,
                        Lastname = student.Lastname,
                        DepartmentId = departmentId,
                        SectionId = section.SectionId
                    };
                    _context.Add(stud);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Student added successfully!";
                    return RedirectToAction("AddStudent", new StudentCourseView { DepartmentId = departmentId });
                }
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentId", student.DepartmentId);
            ViewData["SectionId"] = new SelectList(_context.Set<Section>(), "SectionId", "SectionId", student.SectionId);
            return View(student);
        }

        private bool DepartmentExists(int id)
        {
            return _context.Department.Any(e => e.DepartmentId == id);
        }

    }
}
