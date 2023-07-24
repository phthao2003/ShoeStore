using ShoeStore.Shared;

namespace ShoeStore.Areas.Admin.ViewModels;

public class ProductViewModel
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string NameNormalization { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }

    public ProductStatusEnum Status { get; set; }

    public InventoryStatus InventoryStatus { get; set; }

    public DateTime CreationTime { get; set; }
    public DateTime? LastModificationTime { get; set; }
}