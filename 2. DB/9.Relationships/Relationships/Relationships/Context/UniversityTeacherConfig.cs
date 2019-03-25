using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Relationships.DAL.Models;

namespace Relationships.DAL.Context
{
    public class UniversityTeacherConfig : IEntityTypeConfiguration<UniversityTeacher>
    {
        public void Configure(EntityTypeBuilder<UniversityTeacher> builder)
        {
            builder.ToTable("UniversityTeachers");
            builder.HasKey(ab => new {ab.TeacherId, ab.UniversityId});
        }
    }
}