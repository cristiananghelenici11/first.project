using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Configurations
{
    public class MarkTeacherConfiguration : IEntityTypeConfiguration<MarkTeacher>
    {
        public void Configure(EntityTypeBuilder<MarkTeacher> builder)
        {
            builder.HasOne(d => d.Teacher)
                .WithMany(p => p.MarkTeachers)
                   .HasForeignKey(d => d.TeacherId)
                   .HasConstraintName("FK_MarkTeacherToTeacher");
        }
    }
}