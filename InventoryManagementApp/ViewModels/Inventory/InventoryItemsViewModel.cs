using InventoryManagementApp.Models;

namespace InventoryManagementApp.ViewModels.Inventory
{
    public class InventoryItemsViewModel
    {
        public Models.Inventory Inventory { get; set; } = null!;

        public InventoryItem NewItem { get; set; } = new();
        public List<InventoryItem> Items { get; set; } = new();
    }
}
