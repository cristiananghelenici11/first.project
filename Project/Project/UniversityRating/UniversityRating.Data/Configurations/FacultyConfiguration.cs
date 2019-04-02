using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Configurations
{
    public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder.Property(e => e.Address)
                   .IsRequired()
                   .HasMaxLength(128);

            builder.Property(e => e.Description)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(64);

            builder.HasOne(d => d.Universtity)
                   .WithMany(p => p.Faculties)
                   .HasForeignKey(d => d.UniverstityId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_FacultyToUniversity");
        }
    }
}