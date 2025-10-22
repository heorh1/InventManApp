using System.ComponentModel.DataAnnotations;

namespace InventoryManagementApp.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public string? CreatorId { get; set; }
        public ApplicationUser? Creator { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public bool IsPublic { get; set; } = false;

        public string? ImageUrl { get; set; }

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

        public ICollection<InventoryItem>? Items { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
