using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace KurssiBackend.Models
{
    public partial class KurssiDBContext : DbContext
    {
        public KurssiDBContext()
        {
        }

        public KurssiDBContext(DbContextOptions<KurssiDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kurssit> Kurssit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-UBQPUL3D\\SQLEXSIMOSI;Database=KurssiDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kurssit>(entity =>
            {
                entity.HasKey(e => e.KurssiId);

                entity.ToTable("Kurssit");

                entity.Property(e => e.KurssiId).HasColumnName("KurssiID");

                entity.Property(e => e.Nimi)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
