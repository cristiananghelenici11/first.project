using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ACDB.Models
{
    public partial class ACDBContext : DbContext
    {
        public ACDBContext()
        {
        }

        public ACDBContext(DbContextOptions<ACDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<PackGrades> PackGrades { get; set; }
        public virtual DbSet<Packages> Packages { get; set; }
        public virtual DbSet<Sectors> Sectors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=MDDSK40062\SQLEXPRESS;Initial Catalog=ACDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("cst_id_pk");

                entity.ToTable("customers");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("Birth_Date")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("First_Name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.JoinDate)
                    .HasColumnName("Join_Date")
                    .HasColumnType("date");

                entity.Property(e => e.LastName)
                    .HasColumnName("Last_Name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MainPhoneNum)
                    .IsRequired()
                    .HasColumnName("main_phone_num")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.MonthlyDiscount)
                    .HasColumnName("monthly_discount")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.PackId).HasColumnName("pack_id");

                entity.Property(e => e.SecondaryPhoneNum)
                    .HasColumnName("secondary_phone_num")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.Pack)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.PackId)
                    .HasConstraintName("pck_id_fk");
            });

            modelBuilder.Entity<PackGrades>(entity =>
            {
                entity.HasKey(e => e.GradeId)
                    .HasName("grade_id_pk");

                entity.ToTable("pack_grades");

                entity.Property(e => e.GradeId).HasColumnName("grade_id");

                entity.Property(e => e.GradeName)
                    .HasColumnName("grade_name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MaxPrice).HasColumnName("max_price");

                entity.Property(e => e.MinPrice).HasColumnName("min_price");
            });

            modelBuilder.Entity<Packages>(entity =>
            {
                entity.HasKey(e => e.PackId)
                    .HasName("pack_id_pk");

                entity.ToTable("packages");

                entity.Property(e => e.PackId).HasColumnName("pack_id");

                entity.Property(e => e.MonthlyPayment).HasColumnName("monthly_payment");

                entity.Property(e => e.SectorId).HasColumnName("sector_id");

                entity.Property(e => e.Speed)
                    .HasColumnName("speed")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StrtDate)
                    .HasColumnName("strt_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.SectorId)
                    .HasConstraintName("sec_id_fk");
            });

            modelBuilder.Entity<Sectors>(entity =>
            {
                entity.HasKey(e => e.SectorId)
                    .HasName("sec_id_pk");

                entity.ToTable("sectors");

                entity.Property(e => e.SectorId).HasColumnName("sector_id");

                entity.Property(e => e.SectorName)
                    .HasColumnName("sector_name")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
        }
    }
}
