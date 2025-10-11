using InventoryManagementApp.Models;
using Microsoft.EntityFrameworkCore;
namespace InventoryManagementApp.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public ApplicationDbContext() 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
