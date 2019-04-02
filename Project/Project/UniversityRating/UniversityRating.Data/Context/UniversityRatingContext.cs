using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Context
{
    public class UniversityRatingContext : DbContext
    {
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentTeacher> CommentTeachers { get; set; }
        public virtual DbSet<CommentCourse> CommentCourses { get; set; }
        public virtual DbSet<CommentCourseTeacher> CommentCourseTeachers { get; set; }
        public virtual DbSet<CourseTeacher> CourseTeachers { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<MarkCourse> MarkCourses { get; set; }
        public virtual DbSet<MarkTeacher> MarkTeachers { get; set; }
        public virtual DbSet<MarkCourseTeacher> MarkCourseTeachers { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<UniversityTeacher> UniversityTeachers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Amdaris
            //optionsBuilder.UseSqlServer(@"Data Source=MDDSK40062\SQLEXPRESS;Initial Catalog=University;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            //home
            optionsBuilder.UseSqlServer(@"Data Source=CRISTIAN\SQLEXPRESS;Initial Catalog=University;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

    }
}