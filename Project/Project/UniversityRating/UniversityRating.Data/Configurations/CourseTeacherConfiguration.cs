using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Configurations
{
    public class CourseTeacherConfiguration : IEntityTypeConfiguration<CourseTeacher>
    {
        public void Configure(EntityTypeBuilder<CourseTeacher> builder)
        {
            builder.HasIndex(e => new { e.TeacherId, e.CourseId })
                   .HasName("UK_CourseTeachers")
                   .IsUnique();

            builder.HasOne(d => d.Course)
                   .WithMany(p => p.CourseTeachers)
                   .HasForeignKey(d => d.CourseId)
                   .HasConstraintName("FK_CPToCourses");

            builder.HasOne(d => d.Teacher)
                   .WithMany(p => p.CourseTeachers)
                   .HasForeignKey(d => d.TeacherId)
                   .HasConstraintName("FK_CPToTeachers");
        }
    }
}