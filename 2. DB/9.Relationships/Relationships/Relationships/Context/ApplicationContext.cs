using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        public string UniversityTeachers { get; set; }
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

            modelBuilder.Entity<Student>().HasData(new Student()
                { Id = 1, UniversityId = 1, FirstName = "wqrewqr", Phone = 1356});

            modelBuilder.Entity<Address>().HasData(new Address()
                { Id = 1, ZipCode = "erw", City = "Chisinau", State = "ssde", StudentId = 1});
            
//            modelBuilder.Entity<Student>().OwnsOne(x => x.University).HasData( new University
//            {Id = 3, Name = "UTM", Address = "Studentilor",  Age = 30, Description = "utm---3--", Contact = "245322" });

        }
    }
}
