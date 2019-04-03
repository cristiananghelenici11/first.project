using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Configurations
{
    public class CommentTeacherConfiguration : IEntityTypeConfiguration<CommentTeacher>
    {
        public void Configure(EntityTypeBuilder<CommentTeacher> builder)
        {
            builder.HasOne(x => x.Teacher)
                .WithMany(p => p.CommentTeachers)
                .HasForeignKey(c => c.TeacherId)
                .HasConstraintName("FK_CommentTeacherToTeacher");
        }
    }
}