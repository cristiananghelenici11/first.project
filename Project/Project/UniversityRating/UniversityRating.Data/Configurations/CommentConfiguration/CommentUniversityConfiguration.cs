using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Configurations.Comment
{
    public class CommentUniversityConfiguration : IEntityTypeConfiguration<CommentUniversity>
    {
        public void Configure(EntityTypeBuilder<CommentUniversity> builder)
        {
            builder.HasOne(x => x.University)
                   .WithMany(p => p.CommentUniversities)
                   .HasForeignKey(k => k.UniversityId)
                   .HasConstraintName("FK_CommentUniversitiesToUniversity");
        }
    }
}