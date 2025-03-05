using Microsoft.EntityFrameworkCore;
using serverSide.DTO;
using serverSide.Models;

namespace serverSide.Data
{
    public class CDKDbContext : DbContext
    {
        public CDKDbContext(DbContextOptions<CDKDbContext> context) : base(context) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<StudentInstructorEvaluation> StudentInstructorEvaluations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<StudentCourse>()
         .HasKey(sc => new { sc.StudentId, sc.CourseId, sc.FacultyId, sc.ScheduleId});

            modelBuilder.Entity<StudentInstructorEvaluation>()
                .HasKey(sie => new { sie.StudentId, sie.FacultyId, sie.EvaluationId });

            modelBuilder.Entity<InstructorCourse>()
                .HasKey(ic => new {ic.FacultyId, ic.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Schedule)
                .WithOne(s => s.StudentCourse)
                .HasForeignKey<StudentCourse>(sc => sc.ScheduleId);

            modelBuilder.Entity<Faculty>()
                .HasMany(i => i.InstructorCourses)
                .WithOne(ic => ic.Instructor)
                .HasForeignKey(ic => ic.FacultyId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.InstructorCourses)
                .WithOne(ic => ic.Course)
                .HasForeignKey(ic => ic.CourseId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Faculty)
                .WithMany()
                .HasForeignKey(sc => sc.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Schedule)
                .HasForeignKey(s => s.CourseId);
           
            //Student's Evaluation
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Evaluations)
                .WithOne(sie => sie.Student)
                .HasForeignKey(sie => sie.StudentId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Faculty>()
                .HasMany(i => i.Evaluations)
                .WithOne(sie => sie.Faculty)
                .HasForeignKey(sie => sie.FacultyId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Faculties)
                .WithOne(i => i.Department)
                .HasForeignKey(i => i.DepartmentId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
               .HasMany(d => d.Students)
               .WithOne(s => s.Department)
               .HasForeignKey(s => s.DepartmentId).OnDelete(DeleteBehavior.Restrict);
        }

    }
}
