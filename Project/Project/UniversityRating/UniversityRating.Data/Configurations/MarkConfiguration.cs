using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Configurations
{
    public class MarkConfiguration : IEntityTypeConfiguration<Mark>
    {
        public void Configure(EntityTypeBuilder<Mark> builder)
        {
            builder.HasIndex(e => new { e.TeacherId, e.CourseId, e.UserId })
                   .HasName("UC_Marks")
                   .IsUnique();

            builder.Property(e => e.TypeMark)
                   .IsRequired()
                   .HasMaxLength(64);

            builder.HasOne(d => d.Course)
                   .WithMany(p => p.Marks)
                   .HasForeignKey(d => d.CourseId)
                   .HasConstraintName("FK_MarksToCourse");

            builder.HasOne(d => d.Teacher)
                   .WithMany(p => p.Marks)
                   .HasForeignKey(d => d.TeacherId)
                   .HasConstraintName("FK_MarksToTeachers");

            builder.HasOne(d => d.User)
                   .WithMany(p => p.Marks)
                   .HasForeignKey(d => d.UserId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_MarksToUsers");
        }
    }
}