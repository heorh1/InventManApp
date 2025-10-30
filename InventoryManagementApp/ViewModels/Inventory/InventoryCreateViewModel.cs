namespace InventoryManagementApp.ViewModels.Inventory
{
    public class InventoryCreateViewModel
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public bool IsPublic { get; set; }

        // Single-line text fields
        public bool CustomString1State { get; set; }
        public string? CustomString1Name { get; set; }
        public string? CustomString1Description { get; set; }

        public bool CustomString2State { get; set; }
        public string? CustomString2Name { get; set; }
        public string? CustomString2Description { get; set; }

        public bool CustomString3State { get; set; }
        public string? CustomString3Name { get; set; }
        public string? CustomString3Description { get; set; }

        // Numeric fields
        public bool CustomInt1State { get; set; }
        public string? CustomInt1Name { get; set; }
        public string? CustomInt1Description { get; set; }

        public bool CustomInt2State { get; set; }
        public string? CustomInt2Name { get; set; }
        public string? CustomInt2Description { get; set; }

        public bool CustomInt3State { get; set; }
        public string? CustomInt3Name { get; set; }
        public string? CustomInt3Description { get; set; }

        // Boolean fields
        public bool CustomBool1State { get; set; }
        public string? CustomBool1Name { get; set; }
        public string? CustomBool1Description { get; set; }

        public bool CustomBool2State { get; set; }
        public string? CustomBool2Name { get; set; }
        public string? CustomBool2Description { get; set; }

        public bool CustomBool3State { get; set; }
        public string? CustomBool3Name { get; set; }
        public string? CustomBool3Description { get; set; }

        // Multi-line text fields
        public bool CustomMultiline1State { get; set; }
        public string? CustomMultiline1Name { get; set; }
        public string? CustomMultiline1Description { get; set; }

        public bool CustomMultiline2State { get; set; }
        public string? CustomMultiline2Name { get; set; }
        public string? CustomMultiline2Description { get; set; }

        public bool CustomMultiline3State { get; set; }
        public string? CustomMultiline3Name { get; set; }
        public string? CustomMultiline3Description { get; set; }

        // Document/Image fields
        public bool CustomLink1State { get; set; }
        public string? CustomLink1Name { get; set; }
        public string? CustomLink1Description { get; set; }

        public bool CustomLink2State { get; set; }
        public string? CustomLink2Name { get; set; }
        public string? CustomLink2Description { get; set; }

        public bool CustomLink3State { get; set; }
        public string? CustomLink3Name { get; set; }
        public string? CustomLink3Description { get; set; }
    }
}
