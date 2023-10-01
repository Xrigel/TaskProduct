using Microsoft.EntityFrameworkCore;
using TaskBook.Models;

namespace TaskBook.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_Author> Product_Authors { get; set; }
        public DbSet<Author> Authors { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //davamyaret urtiertoba Product-sa da product_authors shoris
            modelBuilder.Entity<Product_Author>()
                .HasOne(p => p.Product)
                .WithMany(ap => ap.Product_Authors)
                .HasForeignKey(pi => pi.ProductId);

            modelBuilder.Entity<Product_Author>()
                .HasOne(p => p.Author)
                .WithMany(ap => ap.Product_Authors)
                .HasForeignKey(ai => ai.AuthorId);
        }

    }
}
