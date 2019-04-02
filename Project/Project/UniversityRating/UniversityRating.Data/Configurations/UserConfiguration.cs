using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(e => e.Email)
                   .HasName("UK_UserEmail")
                   .IsUnique();

            builder.HasIndex(e => e.Idnp)
                   .HasName("UK_UserIdnp")
                   .IsUnique();

            builder.HasIndex(e => e.Password)
                   .HasName("UK_UserPassword")
                   .IsUnique();

            builder.Property(e => e.Email)
                   .IsRequired()
                   .HasMaxLength(64);

            builder.Property(e => e.FirstName).HasMaxLength(64);

            builder.Property(e => e.LastName).HasMaxLength(64);

            builder.Property(e => e.Password).HasMaxLength(64);

            builder.Property(e => e.Phone)
                   .IsRequired()
                   .HasMaxLength(64)
                   .IsUnicode(false);

            builder.Property(e => e.UserName).HasMaxLength(64);
        }
    }
}