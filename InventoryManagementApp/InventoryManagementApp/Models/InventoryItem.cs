using System.ComponentModel.DataAnnotations;

namespace InventoryManagementApp.Models
{
    public class InventoryItem
    {
        [Key]
        public required string Id { get; set; }


    }
}
