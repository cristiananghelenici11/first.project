using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder.Property(e => e.FirstName).HasMaxLength(64);

            builder.Property(e => e.LastName).HasMaxLength(64);

//            builder.HasMany(x => x.Marks)
//                .WithOne(p => p.Customer)
//                .HasForeignKey(k => k.UserId)
//                .HasConstraintName("FK_UserToMark");
//
//            builder.HasMany(x => x.Comments)
//                .WithOne(p => p.Customer)
//                .HasForeignKey(k => k.UserId)
//                .HasConstraintName("FK_UserToComment");
        }
    }
}