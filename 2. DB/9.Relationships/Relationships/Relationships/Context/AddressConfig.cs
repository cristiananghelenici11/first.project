using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Relationships.DAL.Models;

namespace Relationships.DAL.Context
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasOne(x => x.Student)
                .WithOne(x => x.Address)
                .HasForeignKey<Address>(y => y.StudentId);

            builder.Property(x => x.RowVersion)
                .IsRowVersion();
        }
        
    }
}