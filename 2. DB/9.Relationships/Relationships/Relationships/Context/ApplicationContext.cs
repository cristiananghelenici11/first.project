using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Relationships.DAL.Models;

namespace Relationships.DAL.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {

        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<University> Universities { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<UniversityTeacher> UniversityTeachers { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<MarkCourse> MarkCourses { get; set; }
        public DbSet<MarkTeacher> MarkTeachers { get; set; }
        public DbSet<MarkCourseTeacher> MarkCourseTeachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=MDDSK40062\SQLEXPRESS;Initial Catalog=Relationships;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<University>().HasData(new University()
            { Id = 1, Name = "UTM", Address = "Studentilor", Age = 30, Description = "utm-----", Contact = "245322"});

            modelBuilder.Entity<University>().HasData( new
            {Id = (long)2, Name = "UTM", Address = "Studentilor",  Age = 30, Description = "utm-----", Contact = "245322" });
            
//            modelBuilder.Entity<University>().OwnsOne(x => x.Students).HasData( new
//            {Id = (long)6, Name = "UTM", Address = "Studentilor",  Age = 30, Description = "utm-----", Contact = "245322" });

        }
    }
}
