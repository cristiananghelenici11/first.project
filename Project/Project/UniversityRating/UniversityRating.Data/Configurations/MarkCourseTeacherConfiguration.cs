using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Configurations
{
    public class MarkCourseTeacherConfiguration : IEntityTypeConfiguration<MarkCourseTeacher>
    {
        public void Configure(EntityTypeBuilder<MarkCourseTeacher> builder)
        {
            builder.Property(e => e.Value)
                   .IsRequired();

            builder.HasOne(x => x.CourseTeacher)
                .WithMany(p => p.MarkCourseTeachers)
                .HasForeignKey(d => d.CourseTeacherId)
                .HasConstraintName("FK_MarkCourseTeacherToCourseTeacher");
        }
    }
}