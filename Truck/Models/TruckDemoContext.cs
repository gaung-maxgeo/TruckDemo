using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Truck.Models
{
    public partial class TruckDemoContext : DbContext
    {
        public TruckDemoContext()
        {
        }

        public TruckDemoContext(DbContextOptions<TruckDemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Telemetry> Telemetry { get; set; }
        public virtual DbSet<Truck> Truck { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=AU-FRE-L0302;Database=TruckDemo;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Telemetry>(entity =>
            {
                entity.HasOne(d => d.Truck)
                    .WithMany(p => p.Telemetry)
                    .HasForeignKey(d => d.TruckId)
                    .HasConstraintName("FK__Telemetry__Truck__2B3F6F97");
            });

            modelBuilder.Entity<Truck>(entity =>
            {
                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PurchaseDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
