using Microsoft.AspNetCore.Mvc;

namespace SmellIt.Admin.Controllers;
public class ProductsController : Controller
{

    public ProductsController()
    {
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }
}
