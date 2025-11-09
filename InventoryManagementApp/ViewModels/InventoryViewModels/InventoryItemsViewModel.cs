using InventoryManagementApp.Models;

namespace InventoryManagementApp.ViewModels.InventoryViewModels
{
    public class InventoryItemsViewModel
    {
        public int InventoryId { get; set; }
        public string? InventoryTitle { get; set; }
        public Inventory? Inventory { get; set; }

        public List<InventoryItem> Items { get; set; } = new();

        public string? CustomString1Value { get; set; }
        public int? CustomInt1Value { get; set; }
    }
}
