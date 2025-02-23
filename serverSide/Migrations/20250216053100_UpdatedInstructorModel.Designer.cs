﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using serverSide.Data;

#nullable disable

namespace serverSide.Migrations
{
    [DbContext(typeof(CDKDbContext))]
    [Migration("20250216053100_UpdatedInstructorModel")]
    partial class UpdatedInstructorModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("serverSide.Models.Course", b =>
                {
                    b.Property<string>("CourseCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("InstructorId")
                        .HasColumnType("int");

                    b.Property<string>("PrerequisiteFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrerequisiteTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Semester")
                        .HasColumnType("int");

                    b.Property<int>("Units")
                        .HasColumnType("int");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("CourseCode");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("InstructorId")
                        .IsUnique()
                        .HasFilter("[InstructorId] IS NOT NULL");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("serverSide.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SectionId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentCount")
                        .HasColumnType("int");

                    b.HasKey("DepartmentId");

                    b.HasIndex("SectionId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("serverSide.Models.Instructor", b =>
                {
                    b.Property<int>("InstructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstructorId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PortalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("int");

                    b.HasKey("InstructorId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("serverSide.Models.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleId"));

                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("End")
                        .HasColumnType("time");

                    b.Property<int?>("InstructorId")
                        .HasColumnType("int");

                    b.Property<string>("Room")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SectionId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Start")
                        .HasColumnType("time");

                    b.HasKey("ScheduleId");

                    b.HasIndex("CourseId");

                    b.HasIndex("InstructorId")
                        .IsUnique()
                        .HasFilter("[InstructorId] IS NOT NULL");

                    b.HasIndex("SectionId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("serverSide.Models.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SectionId"));

                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("SectionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("SectionId");

                    b.HasIndex("CourseId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("serverSide.Models.Student", b =>
                {
                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Middlename")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PortalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SectionId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SectionId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("serverSide.Models.StudentCourse", b =>
                {
                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<int?>("Final")
                        .HasColumnType("int");

                    b.Property<int?>("GPA")
                        .HasColumnType("int");

                    b.Property<int?>("Midterm")
                        .HasColumnType("int");

                    b.Property<int?>("Prelim")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "CourseId", "ScheduleId", "SectionId", "InstructorId");

                    b.HasIndex("CourseId");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("InstructorId");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("SectionId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("serverSide.Models.Course", b =>
                {
                    b.HasOne("serverSide.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("serverSide.Models.Instructor", "Instructor")
                        .WithOne("Course")
                        .HasForeignKey("serverSide.Models.Course", "InstructorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Department");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("serverSide.Models.Department", b =>
                {
                    b.HasOne("serverSide.Models.Section", null)
                        .WithMany("ListOfDepartments")
                        .HasForeignKey("SectionId");
                });

            modelBuilder.Entity("serverSide.Models.Schedule", b =>
                {
                    b.HasOne("serverSide.Models.Course", "Course")
                        .WithMany("Schedule")
                        .HasForeignKey("CourseId");

                    b.HasOne("serverSide.Models.Instructor", "Instructor")
                        .WithOne("Schedule")
                        .HasForeignKey("serverSide.Models.Schedule", "InstructorId");

                    b.HasOne("serverSide.Models.Section", "Section")
                        .WithMany("Schedule")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Course");

                    b.Navigation("Instructor");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("serverSide.Models.Section", b =>
                {
                    b.HasOne("serverSide.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.HasOne("serverSide.Models.Department", "Department")
                        .WithMany("Sections")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Course");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("serverSide.Models.Student", b =>
                {
                    b.HasOne("serverSide.Models.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("serverSide.Models.Section", "Section")
                        .WithMany("Students")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Department");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("serverSide.Models.StudentCourse", b =>
                {
                    b.HasOne("serverSide.Models.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("serverSide.Models.Department", "Department")
                        .WithMany("StudentCourses")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("serverSide.Models.Instructor", "Instructor")
                        .WithMany()
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("serverSide.Models.Schedule", "Schedule")
                        .WithMany("StudentCourses")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("serverSide.Models.Section", "Section")
                        .WithMany("StudentCourses")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("serverSide.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Department");

                    b.Navigation("Instructor");

                    b.Navigation("Schedule");

                    b.Navigation("Section");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("serverSide.Models.Course", b =>
                {
                    b.Navigation("Schedule");

                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("serverSide.Models.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Sections");

                    b.Navigation("StudentCourses");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("serverSide.Models.Instructor", b =>
                {
                    b.Navigation("Course");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("serverSide.Models.Schedule", b =>
                {
                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("serverSide.Models.Section", b =>
                {
                    b.Navigation("ListOfDepartments");

                    b.Navigation("Schedule");

                    b.Navigation("StudentCourses");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("serverSide.Models.Student", b =>
                {
                    b.Navigation("StudentCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
