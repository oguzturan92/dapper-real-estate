using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Services.AgentServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.ViewComponents.Agent
{
    public class AgentViewComponent : ViewComponent
    {
        private readonly IAgentService _agentService;
        public AgentViewComponent(IAgentService agentService)
        {
            _agentService = agentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _agentService.GetAllAgentAsync();
            return View(values);
        }
    }
}