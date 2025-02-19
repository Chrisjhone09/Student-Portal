using Microsoft.EntityFrameworkCore;
using serverSide.Models;

namespace serverSide.Data
{
    public class CDKDbContext : DbContext
    {
        public CDKDbContext(DbContextOptions<CDKDbContext> context) : base(context) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<serverSide.Models.Department> Department { get; set; } = default!;
        public DbSet<serverSide.Models.Section> Section { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
         .HasKey(sc => new { sc.StudentId, sc.CourseId, sc.ScheduleId, sc.SectionId, sc.InstructorId });

            modelBuilder.Entity<StudentInstructorEvaluation>()
                .HasKey(sie => new { sie.StudentId, sie.InstructorId, sie.EvaluationId });

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
                .HasOne(sc => sc.Schedule)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.ScheduleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Section)
                .WithMany(sec => sec.StudentCourses)
                .HasForeignKey(sc => sc.SectionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Instructor)
                .WithMany()
                .HasForeignKey(sc => sc.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Department)
                .WithMany(d => d.StudentCourses)
                .HasForeignKey(sc => sc.DepartmentID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false); 
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Section)
                .WithMany(sec => sec.Students)
                .HasForeignKey(s => s.SectionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false); 
            modelBuilder.Entity<Section>()
                .HasOne(sec => sec.Department)
                .WithMany(d => d.Sections)
                .HasForeignKey(sec => sec.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false); 

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Instructor)
                .WithOne(i => i.Course)
                .HasForeignKey<Course>(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false); 
            modelBuilder.Entity<Section>()
                .HasMany(s => s.Schedule)
                .WithOne(s => s.Section)
                .HasForeignKey(s => s.SectionId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Courses).WithOne(s => s.Department).HasForeignKey(c => c.DepartmentId);
            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Instructor)
                .WithOne(i => i.Schedule)
                .HasForeignKey<Schedule>(s => s.InstructorId);
            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Schedule)
                .HasForeignKey(s => s.CourseId);
            modelBuilder.Entity<Section>()
                .Property(c => c.StudentCount).HasDefaultValue(0);


            //Student's Evaluation
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Evaluations)
                .WithOne(sie => sie.Student)
                .HasForeignKey(sie => sie.StudentId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Instructor>()
                .HasMany(i => i.Evaluations)
                .WithOne(sie => sie.Instructor)
                .HasForeignKey(sie => sie.InstructorId).OnDelete(DeleteBehavior.Restrict);
        }

    }
}
