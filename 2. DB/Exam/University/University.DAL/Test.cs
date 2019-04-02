//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using University.DAL.Models;
//
//namespace University.DAL
//{
//    public class Test
//    {
//        
//    }
//
//    public class Address
//    {
//        public long Id { get; set; }
//        public string ZipCode { get; set; }
//        public string strada { get; set; }
//        public long StudentId { get; set; }
//        public virtual Student Student { get; set; }
//    }
//
//    public class Course
//    {
//        public long Id { get; set; }
//        public string Name { get; set; }
//        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
//    }
//
//    public class Student
//    {
//        public long Id { get; set; }
//        public string FName { get; set; }
//        public string LName { get; set; }
//        public virtual Address Address { get; set; }
//        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
//    }
//
//    public class StudentCourse
//    {
//        public long Id { get; set; }
//        public long StudentId { get; set; }
//        public virtual Student Student { get; set; }
//        public long CourseId { get; set; }
//        public virtual Course Course{get; set;}
//        public int Mark { get; set; }
//    }
//
//    public class UniversityContext1 : DbContext
//    {
//        public DbSet<Address> Addresses { get; set; }
//        public DbSet<Student> Students { get; set; }
//        public DbSet<StudentCourse> StudentCourses { get; set; }
//        public DbSet<Course> Courses { get; set; }
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseSqlServer(@"Data Source=CRISTIAN\SQLEXPRESS;Initial Catalog=University;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
//        }
//
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            //modelBuilder.Entity(x=> x.HasKey(d=> d.))
//        }
//    }
//}