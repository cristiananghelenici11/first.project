using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Configurations
{
    public class CommentCourseConfiguration : IEntityTypeConfiguration<CommentCourse>
    {
        public void Configure(EntityTypeBuilder<CommentCourse> builder)
        {
            
            builder.HasOne(d => d.Course)
                .WithMany(p => p.CommentCourses)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_CommentCourseToCourse");
        }
    }
}