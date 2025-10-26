namespace InventoryManagementApp.ViewModels.Inventory
{
    public class InventoryDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsPublic { get; set; }

        public string? CategoryName { get; set; }
        public string CreatorName { get; set; } = null!;

        public string? CustomString1Name { get; set; }
        public string? CustomString2Name { get; set; }
        public string? CustomString3Name { get; set; }

        public string? CustomInt1Name { get; set; }
        public string? CustomInt2Name { get; set; }
        public string? CustomInt3Name { get; set; }

        public string? CustomBool1Name { get; set; }
        public string? CustomBool2Name { get; set; }
        public string? CustomBool3Name { get; set; }
    }
}
