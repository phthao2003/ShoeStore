using ShoeStore.Shared;

namespace ShoeStore.Areas.Admin.ViewModels;

public class CreateProductViewModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }

    public ProductStatusEnum Status { get; set; }

    public InventoryStatus InventoryStatus { get; set; }
}