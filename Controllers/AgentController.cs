using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.Controllers
{
    public class AgentController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.agentActive = "active";
            return View();
        }   
    }
}