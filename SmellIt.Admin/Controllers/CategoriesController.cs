using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.Dtos;
using SmellIt.Application.Services.Interfaces;

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