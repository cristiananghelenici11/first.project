using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasIndex(e => new { e.TeacherId, e.CourseId, e.UserId })
                   .HasName("UC_Coments")
                   .IsUnique();

            builder.Property(e => e.Message).IsRequired();

            builder.Property(e => e.Subject).HasMaxLength(64);

            builder.HasOne(d => d.Course)
                   .WithMany(p => p.Comments)
                   .HasForeignKey(d => d.CourseId)
                   .HasConstraintName("FK_CommentToCourses");

            builder.HasOne(d => d.Teacher)
                   .WithMany(p => p.Comments)
                   .HasForeignKey(d => d.TeacherId)
                   .HasConstraintName("FK_CommentToTeachers");

            builder.HasOne(d => d.User)
                   .WithMany(p => p.Comments)
                   .HasForeignKey(d => d.UserId)
                   .HasConstraintName("FK_CommentToUsers");
        }
    }
}