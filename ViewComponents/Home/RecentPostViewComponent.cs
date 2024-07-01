using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Services.PropertyServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.ViewComponents.Home
{
    public class RecentPostViewComponent : ViewComponent
    {
        private readonly IPropertyService _propertyService;
        public RecentPostViewComponent(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _propertyService.GetRecentPropertyAsync();
            return View(values);
        }
    }
}