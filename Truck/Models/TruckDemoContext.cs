using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TruckAPI.Models
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

        public virtual DbSet<Telemetry> Telemetries { get; set; }
        public virtual DbSet<Truck> Trucks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=TruckDemo");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Telemetry>(entity =>
            {
                entity.ToTable("Telemetry");

                entity.HasOne(d => d.Truck)
                    .WithMany(p => p.Telemetries)
                    .HasForeignKey(d => d.TruckId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Telemetry_Truck");
            });

            modelBuilder.Entity<Truck>(entity =>
            {
                entity.ToTable("Truck");

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
