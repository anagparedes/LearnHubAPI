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
    public class LearnHubDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Admin> Administrators { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        public LearnHubDbContext(DbContextOptions<LearnHubDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetAssembly(typeof(LearnHubDbContext));
            
            if (assembly is not null)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            }
            modelBuilder.Entity<StudentCourse>()
            .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(sc => sc.CourseId);
            base.OnModelCreating(modelBuilder);
            

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
