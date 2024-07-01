using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.Controllers
{
    public class PropertyController : Controller
    {
        public IActionResult Index(string q, int location, float minPrice, float maxPrice, int page=1)
        {
            ViewBag.q = q;
            ViewBag.location = location;
            ViewBag.minPrice = minPrice;
            ViewBag.maxPrice = maxPrice;
            ViewBag.page = page;

            ViewBag.propertyActive = "active";
            return View();
        }

        public IActionResult Detail(int id)
        {
            ViewBag.propertyActive = "active";
            ViewBag.id = id;
            return View();
        }   
    }
}