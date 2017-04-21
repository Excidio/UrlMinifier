using Microsoft.EntityFrameworkCore;
using UrlMinifier.Domain;

namespace UrlMinifier.Repository
{
    public class UrlContext : DbContext
    {
        public UrlContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MinifiedUrl> MinifiedUrls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MinifiedUrl>().ToTable("MinifiedUrls");
        }
    }
}
