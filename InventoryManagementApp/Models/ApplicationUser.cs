using Microsoft.AspNetCore.Identity;
using System.Globalization;
namespace InventoryManagementApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }

        public DateTime DateRegistred { get; set; }

    }
}
