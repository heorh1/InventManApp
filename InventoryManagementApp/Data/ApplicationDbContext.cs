using InventoryManagementApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InventoryManagementApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();
        public DbSet<Inventory> Inventories => Set<Inventory>();
        public DbSet<Category> Categories => Set<Category>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Связь Inventory ↔ Creator
            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.Creator)
                .WithMany(u => u.Inventories)
                .HasForeignKey(i => i.CreatorId)
                .OnDelete(DeleteBehavior.SetNull);

            // Связь Inventory ↔ Category
            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.Category)
                .WithMany(c => c.Inventories)
                .HasForeignKey(i => i.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
