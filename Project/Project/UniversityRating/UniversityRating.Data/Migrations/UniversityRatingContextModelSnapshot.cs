﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityRating.Data.Context;

namespace UniversityRating.Data.Migrations
{
    [DbContext(typeof(UniversityRatingContext))]
    partial class UniversityRatingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UniversityRating.Data.Core.DomainModels.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CourseId");

                    b.Property<string>("Message")
                        .IsRequired();

                    b.Property<string>("Subject")
                        .HasMaxLength(64);

                    b.Property<long?>("TeacherId");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.HasIndex("TeacherId", "CourseId", "UserId")
                        .IsUnique()
                        .HasName("UC_Coments")
                        .HasFilter("[TeacherId] IS NOT NULL AND [CourseId] IS NOT NULL AND [UserId] IS NOT NULL");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("UniversityRating.Data.Core.DomainModels.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Credits");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<long>("FacultyId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<int>("YearOfStudy");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("UniversityRating.Data.Core.DomainModels.CourseTeacher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CourseId");

                    b.Property<long?>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId", "CourseId")
                        .IsUnique()
                        .HasName("UK_CourseTeachers")
                        .HasFilter("[TeacherId] IS NOT NULL AND [CourseId] IS NOT NULL");

                    b.ToTable("CourseTeachers");
                });

            modelBuilder.Entity("UniversityRating.Data.Core.DomainModels.Faculty", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<long>("UniverstityId");

                    b.HasKey("Id");

                    b.HasIndex("UniverstityId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("UniversityRating.Data.Core.DomainModels.Mark", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CourseId");

                    b.Property<long?>("TeacherId");

                    b.Property<string>("TypeMark")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<long>("UserId");

                    b.Property<float?>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.HasIndex("TeacherId", "CourseId", "UserId")
                        .IsUnique()
                        .HasName("UC_Marks")
                        .HasFilter("[TeacherId] IS NOT NULL AND [CourseId] IS NOT NULL");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("UniversityRating.Data.Core.DomainModels.Teacher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<long>("Idnp");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("UK_TeachersEmail");

                    b.HasIndex("Idnp")
                        .IsUnique()
                        .HasName("UK_TeachersIdnp");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("UniversityRating.Data.Core.DomainModels.University", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("Age");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("UniversityRating.Data.Core.DomainModels.UniversityTeacher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("TeacherId");

                    b.Property<long>("UniversityId");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.HasIndex("UniversityId", "TeacherId")
                        .IsUnique()
                        .HasName("UK_UniversityTeachers");

                    b.ToTable("UniversityTeachers");
                });

            modelBuilder.Entity("UniversityRating.Data.Core.DomainModels.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("FirstName")
                        .HasMaxLength(64);

                    b.Property<long>("Idnp");

                    b.Property<string>("LastName")
                        .HasMaxLength(64);

                    b.Property<string>("Password")
                        .HasMaxLength(64);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false);

                    b.Property<string>("UserName")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("UK_UserEmail");

                    b.HasIndex("Idnp")
                        .IsUnique()
                        .HasName("UK_UserIdnp");

                    b.HasIndex("Password")
                        .IsUnique()
                        .HasName("UK_UserPassword")
                        .HasFilter("[Password] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UniversityRating.Data.Core.DomainModels.Comment", b =>
                {
                    b.HasOne("UniversityRating.Data.Core.DomainModels.Course", "Course")
                        .WithMany("Comments")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK_CommentToCourses");

                    b.HasOne("UniversityRating.Data.Core.DomainModels.Teacher", "Teacher")
                        .WithMany("Comments")
                        .HasForeignKey("TeacherId")
                        .HasConstraintName("FK_CommentToTeachers");

                    b.HasOne("UniversityRating.Data.Core.DomainModels.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_CommentToUsers");
                });

            modelBuilder.Entity("UniversityRating.Data.Core.DomainModels.Course", b =>
                {
                    b.HasOne("UniversityRating.Data.Core.DomainModels.Faculty", "Faculty")
                        .WithMany("Courses")
                        .HasForeignKey("FacultyId")
                        .HasConstraintName("FK_CourseToFaculty");
                });

            modelBuilder.Entity("UniversityRating.Data.Core.DomainModels.CourseTeacher", b =>
                {
                    b.HasOne("UniversityRating.Data.Core.DomainModels.Course", "Course")
                        .WithMany("CourseTeachers")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK_CPToCourses");

                    b.HasOne("UniversityRating.Data.Core.DomainModels.Teacher", "Teacher")
                        .WithMany("CourseTeachers")
                        .HasForeignKey("TeacherId")
                        .HasConstraintName("FK_CPToTeachers");
                });

            modelBuilder.Entity("UniversityRating.Data.Core.DomainModels.Faculty", b =>
                {
                    b.HasOne("UniversityRating.Data.Core.DomainModels.University", "Universtity")
                        .WithMany("Faculties")
                        .HasForeignKey("UniverstityId")
                        .HasConstraintName("FK_FacultyToUniversity");
                });

            modelBuilder.Entity("UniversityRating.Data.Core.DomainModels.Mark", b =>
                {
                    b.HasOne("UniversityRating.Data.Core.DomainModels.Course", "Course")
                        .WithMany("Marks")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK_MarksToCourse");

                    b.HasOne("UniversityRating.Data.Core.DomainModels.Teacher", "Teacher")
                        .WithMany("Marks")
                        .HasForeignKey("TeacherId")
                        .HasConstraintName("FK_MarksToTeachers");

                    b.HasOne("UniversityRating.Data.Core.DomainModels.User", "User")
                        .WithMany("Marks")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_MarksToUsers");
                });

            modelBuilder.Entity("UniversityRating.Data.Core.DomainModels.UniversityTeacher", b =>
                {
                    b.HasOne("UniversityRating.Data.Core.DomainModels.Teacher", "Teacher")
                        .WithMany("UniversityTeachers")
                        .HasForeignKey("TeacherId")
                        .HasConstraintName("FK_UPToTeachers");

                    b.HasOne("UniversityRating.Data.Core.DomainModels.University", "University")
                        .WithMany("UniversityTeachers")
                        .HasForeignKey("UniversityId")
                        .HasConstraintName("FK_UPToUniversities");
                });
#pragma warning restore 612, 618
        }
    }
}
