using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using InventoryManagementApp.Models;

namespace InventoryManagementApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // DbSets for entities
        public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();
        public DbSet<Inventory> Inventories => Set<Inventory>();
        public DbSet<Category> Categories => Set<Category>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Inventory ↔ Creator relationship
            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.Creator)           // Inventory has one creator
                .WithMany(u => u.Inventories)     // User can have many inventories
                .HasForeignKey(i => i.CreatorId)  // FK in Inventory table
                .OnDelete(DeleteBehavior.SetNull); // Set null if user deleted

            // Inventory ↔ Category relationship
            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.Category)          // Inventory has one category
                .WithMany(c => c.Inventories)     // Category can have many inventories
                .HasForeignKey(i => i.CategoryId) // FK in Inventory table
                .OnDelete(DeleteBehavior.SetNull); // Set null if category deleted

            // InventoryItem ↔ Inventory relationship
            modelBuilder.Entity<InventoryItem>()
                .HasOne(ii => ii.Inventory)        // InventoryItem belongs to Inventory
                .WithMany(i => i.Items)           // Inventory has many items
                .HasForeignKey(ii => ii.InventoryId) // FK in InventoryItem table
                .OnDelete(DeleteBehavior.Cascade); // Delete items if inventory deleted

            // InventoryItem ↔ CreatedBy (User) relationship
            modelBuilder.Entity<InventoryItem>()
                .HasOne(ii => ii.CreatedBy)       // Item has one creator
                .WithMany()                       // User does not track items collection
                .HasForeignKey(ii => ii.CreatedById)
                .OnDelete(DeleteBehavior.SetNull); // Keep item if user deleted

            modelBuilder.Entity<Inventory>()
                .Property(i => i.RowVersion)
                .IsRowVersion();

            modelBuilder.Entity<InventoryItem>()
                .Property(ii => ii.RowVersion)
                .IsRowVersion();
        }
    }
}