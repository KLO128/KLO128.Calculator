using Microsoft.EntityFrameworkCore;

namespace KLO128.Calculator.Infra.EFCore.SQLite.Db
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CalcEntry> CalcEntries { get; set; } = null!;
        public virtual DbSet<CalcHistory> CalcHistories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=..\\Docs\\Database.sqlite;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalcEntry>(entity =>
            {
                entity.ToTable("CalcEntry");

                entity.HasIndex(e => e.CalcHistoryId, "IXFK_CalcEntry_CalcHistory");

                entity.HasOne(d => d.CalcHistory)
                    .WithMany(p => p.CalcEntries)
                    .HasForeignKey(d => d.CalcHistoryId);
            });

            modelBuilder.Entity<CalcHistory>(entity =>
            {
                entity.ToTable("CalcHistory");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
