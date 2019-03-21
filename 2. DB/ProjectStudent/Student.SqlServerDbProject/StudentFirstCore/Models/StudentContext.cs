using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentFirstCore.Models
{
    public partial class StudentContext : DbContext
    {
        public StudentContext()
        {
        }

        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<CourseTeachers> CourseTeachers { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Faculties> Faculties { get; set; }
        public virtual DbSet<Marks> Marks { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<Universities> Universities { get; set; }
        public virtual DbSet<UniversityTeachers> UniversityTeachers { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=MDDSK40062\\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasIndex(e => new { e.TeacherId, e.CourseId, e.UserId })
                    .HasName("UC_Coments")
                    .IsUnique();

                entity.Property(e => e.Message).IsRequired();

                entity.Property(e => e.Subject).HasMaxLength(64);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_CommentToCourses");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_CommentToTeachers");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_CommentToUsers");
            });

            modelBuilder.Entity<CourseTeachers>(entity =>
            {
                entity.HasIndex(e => new { e.TeacherId, e.CourseId })
                    .HasName("UK_CourseTeachers")
                    .IsUnique();

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseTeachers)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_CPToCourses");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.CourseTeachers)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_CPToTeachers");
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseToFaculty");
            });

            modelBuilder.Entity<Faculties>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.Universtity)
                    .WithMany(p => p.Faculties)
                    .HasForeignKey(d => d.UniverstityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacultyToUniversity");
            });

            modelBuilder.Entity<Marks>(entity =>
            {
                entity.HasIndex(e => new { e.TeacherId, e.CourseId, e.UserId })
                    .HasName("UC_Marks")
                    .IsUnique();

                entity.Property(e => e.TypeMark)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_MarksToCourse");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_MarksToTeachers");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarksToUsers");
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UK_TeachersEmail")
                    .IsUnique();

                entity.HasIndex(e => e.Idnp)
                    .HasName("UK_TeachersIdnp")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Universities>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<UniversityTeachers>(entity =>
            {
                entity.HasIndex(e => new { e.UniversityId, e.TeacherId })
                    .HasName("UK_UniversityTeachers")
                    .IsUnique();

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.UniversityTeachers)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UPToTeachers");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.UniversityTeachers)
                    .HasForeignKey(d => d.UniversityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UPToUniversities");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UK_UserEmail")
                    .IsUnique();

                entity.HasIndex(e => e.Idnp)
                    .HasName("UK_UserIdnp")
                    .IsUnique();

                entity.HasIndex(e => e.Password)
                    .HasName("UK_UserPassword")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.FirstName).HasMaxLength(64);

                entity.Property(e => e.LastName).HasMaxLength(64);

                entity.Property(e => e.Password).HasMaxLength(64);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.UserName).HasMaxLength(64);
            });
        }
    }
}
