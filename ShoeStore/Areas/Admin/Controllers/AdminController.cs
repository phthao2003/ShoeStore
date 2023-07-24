using Microsoft.AspNetCore.Mvc;

namespace ShoeStore.Areas.Admin.Controllers;

public class AdminController : Controller
{
    public Task<IActionResult> Index()
    {
        return Task.FromResult<IActionResult>(View());
    }
}