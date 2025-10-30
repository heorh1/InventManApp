using System.ComponentModel.DataAnnotations;

namespace InventoryManagementApp.Models
{
    public class InventoryItem
    {
        [Key]
        public int Id { get; set; }

        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; } = null!;

        public string? CreatedById { get; set; }
        public ApplicationUser? CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? CustomString1Value { get; set; }
        public string? CustomString2Value { get; set; }
        public string? CustomString3Value { get; set; }

        public int? CustomInt1Value { get; set; }
        public int? CustomInt2Value { get; set; }
        public int? CustomInt3Value { get; set; }

        public bool? CustomBool1Value { get; set; }
        public bool? CustomBool2Value { get; set; }
        public bool? CustomBool3Value { get; set; }

        public string? CustomMultiline1Value { get; set; }
        public string? CustomMultiline2Value { get; set; }
        public string? CustomMultiline3Value { get; set; }

        public string? CustomDocument1Value { get; set; }
        public string? CustomDocument2Value { get; set; }
        public string? CustomDocument3Value { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
