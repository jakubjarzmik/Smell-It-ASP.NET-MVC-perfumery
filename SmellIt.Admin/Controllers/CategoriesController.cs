using Microsoft.AspNetCore.Mvc;

namespace SmellIt.Admin.Controllers;
public class CategoriesController : Controller
{
    public CategoriesController()
    {
    }
    public IActionResult Index()
    {
        return View();
    }
}