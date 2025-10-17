using Microsoft.AspNetCore.Identity;
using System.Globalization;
namespace InventoryManagementApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }

        public DateTime DateRegistered { get; set; } = DateTime.UtcNow;

        public ICollection<Inventory>? Inventories { get; set; }
    }
}
