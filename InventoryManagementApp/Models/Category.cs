namespace InventoryManagementApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        // Связь с инвентарями
        public ICollection<Inventory>? Inventories { get; set; }
    }
}
