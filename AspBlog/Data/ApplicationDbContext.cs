using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspBlog.Models;

namespace AspBlog.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PageContent> PageContent { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<Comments> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comments>()
                .HasOne(c => c.Games)
                .WithMany(g => g.Commentars)
                .HasForeignKey(c => c.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comments>()
                .HasOne(c => c.PageContent)
                .WithMany(p => p.Commentars)
                .HasForeignKey(c => c.NewsId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
