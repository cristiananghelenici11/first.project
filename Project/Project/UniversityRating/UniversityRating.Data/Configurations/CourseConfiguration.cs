using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(e => e.Description)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(64);

            builder.HasOne(d => d.Faculty)
                   .WithMany(p => p.Courses)
                   .HasForeignKey(d => d.FacultyId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_CourseToFaculty");
        }
    }
}