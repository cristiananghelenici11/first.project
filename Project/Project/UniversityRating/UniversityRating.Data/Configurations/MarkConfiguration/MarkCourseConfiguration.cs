using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Configurations
{
    public class MarkCourseConfiguration : IEntityTypeConfiguration<MarkCourse>
    {
        public void Configure(EntityTypeBuilder<MarkCourse> builder)
        {
            builder.HasOne(x => x.Course)
                .WithMany(p => p.MarkCourses)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_MarkCourseToCourse");
        }
    }
}