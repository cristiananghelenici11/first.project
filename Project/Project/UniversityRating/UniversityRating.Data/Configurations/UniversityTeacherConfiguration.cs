using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Configurations
{
    public class UniversityTeacherConfiguration : IEntityTypeConfiguration<UniversityTeacher>
    {
        public void Configure(EntityTypeBuilder<UniversityTeacher> builder)
        {
            builder.HasIndex(e => new { e.UniversityId, e.TeacherId })
                   .HasName("UK_UniversityTeachers")
                   .IsUnique();

            builder.HasOne(d => d.Teacher)
                   .WithMany(p => p.UniversityTeachers)
                   .HasForeignKey(d => d.TeacherId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_UPToTeachers");

            builder.HasOne(d => d.University)
                   .WithMany(p => p.UniversityTeachers)
                   .HasForeignKey(d => d.UniversityId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_UPToUniversities");
        }
    }
}
