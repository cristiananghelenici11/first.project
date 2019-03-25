using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Relationships.DAL.Models;

namespace Relationships.DAL.Context
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x => x.Idnp)
                .IsRequired()
                .HasMaxLength(13);

            builder.HasOne(x => x.University)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.UniversityId)
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);
        }
    }
}
