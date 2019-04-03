using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Configurations
{
    public class CommentCourseTeacherConfiguration : IEntityTypeConfiguration<CommentCourseTeacher>
    {
        public void Configure(EntityTypeBuilder<CommentCourseTeacher> builder)
        {
            builder.HasOne(x => x.CourseTeacher)
                .WithMany(p => p.CommentCourseTeachers)
                .HasForeignKey(k => k.CourseTeacherId)
                .HasConstraintName("FK_CommentCourseTeacherToCourseTeacher");
        }
    }
}