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
        if (product.Id is null || product.Id == Guid.Empty)
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
        }
        else
        {
            var productToUpdate = await _context.Products.FindAsync(product.Id);

            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Price = product.Price;
                productToUpdate.Description = product.Description;
                productToUpdate.NameNormalization = product.Name.Normalize();
                productToUpdate.Slug = product.Name.Normalize().Replace(" ", "-");
                productToUpdate.LastModificationTime = DateTime.Now;
                productToUpdate.InventoryStatus = product.InventoryStatus;
                productToUpdate.Status = product.Status;
                await _context.SaveChangesAsync();
            }
        }

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

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("List");
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        ViewBag.Action = "Edit";
        var product = await _context.Products.FindAsync(id);

        if (product != null)
        {
            ViewBag.Product = product;
            return View("Create");
        }

        return RedirectToAction("List");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Guid id, CreateProductViewModel productViewModel)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("List");
        }
        
        var productToUpdate = await _context.Products.FindAsync(id);

        if (productToUpdate != null)
        {
            productToUpdate.Name = productViewModel.Name;
            productToUpdate.Price = productViewModel.Price;
            productToUpdate.Description = productViewModel.Description;
            productToUpdate.NameNormalization = productViewModel.Name.Normalize();
            productToUpdate.Slug = productViewModel.Name.Normalize().Replace(" ", "-");
            productToUpdate.LastModificationTime = DateTime.Now;
            productToUpdate.InventoryStatus = productViewModel.InventoryStatus;
            productToUpdate.Status = productViewModel.Status;
            await _context.SaveChangesAsync();
        }
        
        return RedirectToAction("List");
    }
}