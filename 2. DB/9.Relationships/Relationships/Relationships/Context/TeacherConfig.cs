using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Relationships.DAL.Models;

namespace Relationships.DAL.Context
{
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {

            builder.HasMany(x => x.MarkTeachers)
                .WithOne(x => x.Teacher)
                .HasForeignKey(x => x.TeacherId);
           

        }
    }
}
