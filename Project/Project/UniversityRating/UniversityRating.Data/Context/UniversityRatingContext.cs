using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniversityRating.Data.Core.DomainModels;
using UniversityRating.Data.Core.DomainModels.Identity;

namespace UniversityRating.Data.Context
{
    public class UniversityRatingContext : IdentityDbContext<User, Role, long>
    {
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentUniversity> CommentUniversities { get; set; }
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
//        public virtual DbSet<User> Users { get; set; }

        public UniversityRatingContext(DbContextOptions<UniversityRatingContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<User>()
                .ToTable("Users");

            modelBuilder.Entity<Role>()
                .ToTable("Roles");

            modelBuilder.Entity<IdentityUserRole<long>>()
                .ToTable("UserRoles");

            modelBuilder.Entity<IdentityUserToken<long>>()
                .ToTable("UserTokens");

            modelBuilder.Entity<IdentityUserLogin<long>>()
                .ToTable("UserLogins");

            modelBuilder.Entity<IdentityUserClaim<long>>()
                .ToTable("UserClaims");

            modelBuilder.Entity<IdentityRoleClaim<long>>()
                .ToTable("RoleClaims");
        }

    }
}