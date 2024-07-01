using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.aboutActive = "active";
            return View();
        }   
    }
}