using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            
            builder.HasIndex(e => e.Email)
                   .HasName("UK_TeachersEmail")
                   .IsUnique();

            builder.HasIndex(e => e.Idnp)
                   .HasName("UK_TeachersIdnp")
                   .IsUnique();

            builder.Property(e => e.Email)
                   .IsRequired()
                   .HasMaxLength(64);

            builder.Property(e => e.FirstName)
                   .IsRequired()
                   .HasMaxLength(64);

            builder.Property(e => e.LastName)
                   .IsRequired()
                   .HasMaxLength(64);

            builder.Property(e => e.Phone)
                   .IsRequired()
                   .HasMaxLength(64)
                   .IsUnicode(false);
        }
    }
}