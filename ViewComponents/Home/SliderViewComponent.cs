using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Services.PropertyServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.ViewComponents.Home
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly IPropertyService _propertyService;
        public SliderViewComponent(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _propertyService.GetSliderTruePropertyAsync();
            return View(result);
        }
    }
}