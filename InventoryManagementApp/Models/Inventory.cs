namespace InventoryManagementApp.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public string? CreatorId { get; set; }
        public ApplicationUser? Creator { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public int ItemCount { get; set; } // Для топ-5 популярных
    }
}
