using Microsoft.EntityFrameworkCore;
using LearnHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using LearnHub.Domain.Models;

namespace LearnHub.Infrastructure.Context
{
    public class LearnHubDbContext(DbContextOptions<LearnHubDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Admin> Administrators { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<StudentAssignment> StudentAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetAssembly(typeof(LearnHubDbContext));
            
            if (assembly is not null)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            }

            // Relationship between Assignment and Course
            modelBuilder.Entity<Assignment>()
            .HasOne(a => a.Course)
            .WithMany(c => c.Assignments)
            .HasForeignKey(a => a.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
            .HasOne(c => c.AssignedTeacher)
            .WithMany()
            .HasForeignKey(c => c.AssignedTeacherId)
            .OnDelete(DeleteBehavior.Restrict);

            // Relationship between Teacher and Courses
            modelBuilder.Entity<Teacher>()
            .HasMany(t => t.Courses)
            .WithOne(c => c.AssignedTeacher)
            .HasForeignKey(c => c.AssignedTeacherId)
            .OnDelete(DeleteBehavior.Restrict);

            // Relationship between Teacher and Assignment
            modelBuilder.Entity<Teacher>()
            .HasMany(teacher => teacher.CreatedAssignments)
            .WithOne(assignment => assignment.CreatedTeacher)
            .HasForeignKey(assignment => assignment.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

            // Relationship between Teacher and Qualification
            modelBuilder.Entity<Teacher>()
            .HasMany(teacher => teacher.Grades)
            .WithOne(qualification => qualification.EvaluatedTeacher)
            .HasForeignKey(qualification => qualification.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

            // Relationship between Student and Qualification
            modelBuilder.Entity<Student>()
            .HasMany(student => student.Grades)
            .WithOne(qualification => qualification.Student)
            .HasForeignKey(qualification => qualification.StudentId)
            .OnDelete(DeleteBehavior.Restrict);


            //Relationship Many2Many Students and Courses
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            //Relationship Many2Many Students and Assignments
            modelBuilder.Entity<StudentAssignment>()
                .HasKey(sc => new { sc.StudentId, sc.AssignmentId });

            modelBuilder.Entity<StudentAssignment>()
                .HasOne(st => st.Student)
                .WithMany(student => student.AssignedAssignments)
                .HasForeignKey(st => st.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StudentAssignment>()
                .HasOne(asg => asg.Assignment)
                .WithMany(assignment => assignment.AssignedStudents)
                .HasForeignKey(asg => asg.AssignmentId)
                .OnDelete(DeleteBehavior.NoAction);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
