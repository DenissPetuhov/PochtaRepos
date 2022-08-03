using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PorchaAPI
{
    public partial class PochtaRossiiContext : DbContext
    {
        public PochtaRossiiContext()
        {
        }

        public PochtaRossiiContext(DbContextOptions<PochtaRossiiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentHuman> PaymentHumans { get; set; }
        public virtual DbSet<PhoneBook> PhoneBooks { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<StatusTask> StatusTasks { get; set; }
        public virtual DbSet<StatusesBox> StatusesBoxes { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-8PI4GVP;Initial Catalog=PochtaRossii;integrated security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.Property(e => e.Discript).HasMaxLength(50);

                entity.Property(e => e.Number).HasMaxLength(4);

                entity.Property(e => e.VilagerName).HasMaxLength(50);

                entity.HasOne(d => d.IdBuildingNavigation)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.IdBuilding)
                    .HasConstraintName("FK_Apartments_Buildings");

                entity.HasOne(d => d.IdStatusBoxNavigation)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.IdStatusBox)
                    .HasConstraintName("FK_Apartments_StatusesBoxes");
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.Property(e => e.BuildingId).HasColumnName("BuildingID");

                entity.Property(e => e.Discript).HasMaxLength(50);

                entity.Property(e => e.NumberBuilding).HasMaxLength(4);

                entity.HasOne(d => d.IdRegionNavigation)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.IdRegion)
                    .HasConstraintName("FK_Buildings_Regions");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount1).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Amount2).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Amount3).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CountAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CountCoins).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.IdHuman).HasColumnName("idHuman");

                entity.HasOne(d => d.IdHumanNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.IdHuman)
                    .HasConstraintName("FK_Payments_PaymentHumans");
            });

            modelBuilder.Entity<PaymentHuman>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Discript).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PayDate).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.HasOne(d => d.IdApartamentNavigation)
                    .WithMany(p => p.PaymentHumans)
                    .HasForeignKey(d => d.IdApartament)
                    .HasConstraintName("FK_PaymentHumans_Apartments");
            });

            modelBuilder.Entity<PhoneBook>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Discript).HasMaxLength(50);

                entity.Property(e => e.NameOrganisation).HasMaxLength(50);

                entity.Property(e => e.Phone1).HasMaxLength(50);

                entity.Property(e => e.Phone2).HasMaxLength(50);

                entity.Property(e => e.Phone3).HasMaxLength(50);
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.Discript).HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleDiscript)
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusTask>(entity =>
            {
                entity.ToTable("StatusTask");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.StatusTask1)
                    .HasMaxLength(50)
                    .HasColumnName("StatusTask");
            });

            modelBuilder.Entity<StatusesBox>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateTask).HasColumnType("datetime");

                entity.Property(e => e.TextTask).HasMaxLength(150);

                entity.HasOne(d => d.IdPostmanNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.IdPostman)
                    .HasConstraintName("FK_Tasks_Users");

                entity.HasOne(d => d.StatusTaskNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.StatusTask)
                    .HasConstraintName("FK_Tasks_StatusTask");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(16);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.MiddleName).HasMaxLength(16);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.Phone).HasMaxLength(16);

                entity.Property(e => e.ResAdress).HasMaxLength(100);

                entity.HasOne(d => d.IdRegionNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRegion)
                    .HasConstraintName("FK_Users_Regions");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
