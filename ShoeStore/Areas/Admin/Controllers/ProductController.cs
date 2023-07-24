using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoeStore.Areas.Admin.ViewModels;
using ShoeStore.Data;
using ShoeStore.Data.Entities;

namespace ShoeStore.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    private readonly ShoeStoreDbContext _context;

    public ProductController(ShoeStoreDbContext context)
    {
        _context = context;
    }

    public Task<IActionResult> Index()
    {
        return Task.FromResult<IActionResult>(RedirectToAction("List"));
    }

    public Task<IActionResult> Create()
    {
        return Task.FromResult<IActionResult>(View());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductViewModel product)
    {
        var rn = new Random();
        var random = rn.Next(1000, 9999);
        var newProduct = new Product
        {
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            NameNormalization = product.Name.Normalize(),
            Id = Guid.NewGuid(),
            Code = random.ToString().PadLeft(8, '0'),
            Slug = product.Name.Normalize().Replace(" ", "-"),
            CreationTime = DateTime.Now,
            InventoryStatus = product.InventoryStatus,
            Status = product.Status
        };

        await _context.Products.AddAsync(newProduct);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> List()
    {
        var products = await _context.Products.Select(x => new ProductViewModel
        {
            Status = x.Status,
            InventoryStatus = x.InventoryStatus,
            Code = x.Code,
            CreationTime = x.CreationTime,
            Description = x.Description,
            Id = x.Id,
            LastModificationTime = x.LastModificationTime,
            Name = x.Name,
            NameNormalization = x.NameNormalization,
            Price = x.Price,
            Slug = x.Slug
        }).ToListAsync();
        
        ViewBag.Products = products;
        
        return View();
    }
}