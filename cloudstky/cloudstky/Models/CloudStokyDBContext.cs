using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace cloudstky.Models
{
    public partial class CloudStokyDBContext : DbContext
    {
     

        public CloudStokyDBContext(DbContextOptions<CloudStokyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LogEmailConfrim> LogEmailConfrims { get; set; }
        public virtual DbSet<MtbProdType> MtbProdTypes { get; set; }
        public virtual DbSet<MtbUnitType> MtbUnitTypes { get; set; }
        public virtual DbSet<TblAccount> TblAccounts { get; set; }
        public virtual DbSet<TblProdGallery> TblProdGalleries { get; set; }
        public virtual DbSet<TblProduct> TblProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=192.168.1.15;Initial Catalog=CloudStokyDB;Persist Security Info=True;User ID=sa;Password=Admin1234!");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Thai_100_CS_AI");

            modelBuilder.Entity<LogEmailConfrim>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("logEmailConfrim");

                entity.Property(e => e.AccEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<MtbProdType>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.AccName });

                entity.ToTable("mtbProdType");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.AccName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NameEN");

                entity.Property(e => e.NameTh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NameTH");
            });

            modelBuilder.Entity<MtbUnitType>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.AccName });

                entity.ToTable("mtbUnitType");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.AccName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifyBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(10)
                    .HasColumnName("NameEN")
                    .IsFixedLength(true);

                entity.Property(e => e.NameTh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NameTH");
            });

            modelBuilder.Entity<TblAccount>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.AccName })
                    .HasName("PK_Account");

                entity.ToTable("tblAccount");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.AccName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccPwd)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccTel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifyTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblProdGallery>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblProdGallery");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ImageName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.ToTable("tblProduct");

                entity.Property(e => e.AccName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifyBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProdName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProdRemark).HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
