using Microsoft.EntityFrameworkCore;
using UrlMinifier.Domain;

namespace UrlMinifier.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MinifiedUrl> MinifiedUrls { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MinifiedUrl>(entity =>
            {
                entity.Property(e => e.OriginalUrl).IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity
                    .Property(e => e.IpAddress)
                    .IsRequired()
                    .HasMaxLength(15);
            });
        }
    }
}
