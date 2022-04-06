using Microsoft.EntityFrameworkCore;
using ElkPrep.Shared;

namespace ElkPrep.Server.DAL
{
    public partial class ElkPrepContext : DbContext
    {
        public ElkPrepContext()
        {
        }
        public ElkPrepContext(DbContextOptions<ElkPrepContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; } = null;
        public DbSet<Bow> Bows { get; set; } = null;
        public DbSet<Arrow> Arrows { get; set; } = null;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.FirstName).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.LastName).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Age).HasColumnName("Age").IsUnicode(false);
            });

            modelBuilder.Entity<Bow>(entity =>
            {
                entity.ToTable("bows");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Name).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.DrawLength).HasConversion(typeof(decimal)).IsUnicode(false);
                entity.Property(e => e.DrawWeight).HasConversion(typeof(decimal)).IsUnicode(false);
                entity.Property(e => e.LetOff).HasConversion(typeof(int)).IsUnicode(false);
                entity.Property(e => e.FPS).HasConversion(typeof(int)).IsUnicode(false);
                entity.Property(e => e.Range).HasConversion(typeof(int)).IsUnicode(false);
            });

            modelBuilder.Entity<Arrow>(entity =>
            {
                entity.ToTable("arrows");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Name).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Fletch).HasConversion(typeof(int)).IsUnicode(false);
                entity.Property(e => e.Weight).HasConversion(typeof(int)).IsUnicode(false);
                entity.Property(e => e.Length).HasConversion(typeof(int)).IsUnicode(false);
                entity.Property(e => e.Broadhead).HasMaxLength(50).IsUnicode(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
