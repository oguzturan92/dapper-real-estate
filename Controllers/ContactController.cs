using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.contactActive = "active";
            return View();
        }   
    }
}