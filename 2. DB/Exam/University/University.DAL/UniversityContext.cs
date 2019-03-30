using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using University.DAL.Models;

namespace University.DAL
{
    public class UniversityContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=MDDSK40056\SQLEXPRESS;Initial Catalog=University;Integrated Security=True");
        }

    }
}
