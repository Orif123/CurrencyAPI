using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CurrencyAPI.Models.Entities;

#nullable disable

namespace CurrencyAPI.Models.DataContext
{
    public partial class CurrencyTest_DBContext : DbContext
    {
        public CurrencyTest_DBContext()
        {
        }

        public CurrencyTest_DBContext(DbContextOptions<CurrencyTest_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Currency> Currencies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=E:\\ONEDRIVE\\WORKPH\\WORKPHANTOM\\PROJECTSVS_LEARN\\CURRENCYAPI\\CURRENCYAPI\\MODELS\\SERVER\\CURRENCYTEST_DB.MDF;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("Currency");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CurrentDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
