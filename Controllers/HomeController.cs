using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DapperRealEstate.Models;

namespace DapperRealEstate.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
