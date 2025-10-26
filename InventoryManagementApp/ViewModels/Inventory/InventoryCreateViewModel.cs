namespace InventoryManagementApp.ViewModels.Inventory
{
    public class InventoryCreateViewModel
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public bool IsPublic { get; set; }

        public bool CustomString1State { get; set; }
        public string? CustomString1Name { get; set; }
        public bool CustomString2State { get; set; }
        public string? CustomString2Name { get; set; }
        public bool CustomString3State { get; set; }
        public string? CustomString3Name { get; set; }

        public bool CustomInt1State { get; set; }
        public string? CustomInt1Name { get; set; }
        public bool CustomInt2State { get; set; }
        public string? CustomInt2Name { get; set; }
        public bool CustomInt3State { get; set; }
        public string? CustomInt3Name { get; set; }

        public bool CustomBool1State { get; set; }
        public string? CustomBool1Name { get; set; }
        public bool CustomBool2State { get; set; }
        public string? CustomBool2Name { get; set; }
        public bool CustomBool3State { get; set; }
        public string? CustomBool3Name { get; set; }
    }
}
