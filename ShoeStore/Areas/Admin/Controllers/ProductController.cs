using Microsoft.AspNetCore.Mvc;

namespace ShoeStore.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    public Task<IActionResult> Index()
    {
        return Task.FromResult<IActionResult>(View());
    }
}