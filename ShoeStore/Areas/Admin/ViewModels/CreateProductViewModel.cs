using System.ComponentModel.DataAnnotations;
using ShoeStore.Shared;

namespace ShoeStore.Areas.Admin.ViewModels;

public class CreateProductViewModel
{
    public Guid? Id { get; set; }

    [Required] public string Name { get; set; }

    [Required] public decimal Price { get; set; }
    public string Description { get; set; }

    [Required] public ProductStatusEnum Status { get; set; }

    [Required] public InventoryStatus InventoryStatus { get; set; }
}