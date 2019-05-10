using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Configurations
{
    public class UniversityConfiguration : IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> builder)
        {
            builder.Property(e => e.Contact)
                   .IsRequired()
                   .HasMaxLength(64)
                   .IsUnicode(false);

            builder.Property(e => e.Description)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(64);
        }
    }
}