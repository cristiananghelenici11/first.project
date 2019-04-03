using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Core.DomainModels.Comment>
    {
        public void Configure(EntityTypeBuilder<Core.DomainModels.Comment> builder)
        {
            builder.Property(e => e.Message).IsRequired();

            builder.Property(e => e.Subject).IsRequired();

            builder.Property(e => e.UserId).IsRequired();
        }
    }
}