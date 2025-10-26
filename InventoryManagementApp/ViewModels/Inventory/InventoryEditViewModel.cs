namespace InventoryManagementApp.ViewModels.Inventory
{
    public class InventoryEditViewModel : InventoryCreateViewModel
    {
        public int Id { get; set; }

        public byte[]? RowVersion { get; set; }
    }
}
