using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Dtos.AgentDtos;
using DapperRealEstate.Services.AgentServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AgentController : Controller
    {
        private readonly IAgentService _agentService;
        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        public async Task<IActionResult> AgentList()
        {
            ViewBag.agentActive = "active";
            var values = await _agentService.GetAllAgentAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult AgentCreate()
        {
            ViewBag.agentActive = "active";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AgentCreate(CreateAgentDto createAgentDto)
        {
            await _agentService.CreateAgentAsync(createAgentDto);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("AgentList", "Agent");
        }

        [HttpGet]
        public async Task<IActionResult> AgentUpdate(int id)
        {
            ViewBag.agentActive = "active";
            var value = await _agentService.GetAgentAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> AgentUpdate(UpdateAgentDto updateAgentDto)
        {
            await _agentService.UpdateAgentAsync(updateAgentDto);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("AgentList", "Agent");
        }

        public async Task<IActionResult> AgentDelete(int id)
        {
            await _agentService.DeleteAgentAsync(id);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("AgentList", "Agent");
        }
    }
}