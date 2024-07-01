using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Services.CategoryServices;
using DapperRealEstate.Services.LocationServices;
using DapperRealEstate.Services.PropertyServices;
using DapperRealEstate.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.ViewComponents.Home
{
    public class StatisticViewComponent : ViewComponent
    {
        private readonly IPropertyService _propertyService;
        private readonly ICategoryService _categoryService;
        private readonly ILocationService _locationService;
        private readonly ITestimonialService _testimonialService;
        public StatisticViewComponent(IPropertyService propertyService, ITestimonialService testimonialService, ILocationService locationService, ICategoryService categoryService)
        {
            _propertyService = propertyService;
            _testimonialService = testimonialService;
            _locationService = locationService;
            _categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.propertyCount = await _propertyService.GetPropertyCount();
            ViewBag.categoryCount = await _categoryService.GetCategoryCount();
            ViewBag.locationCount = await _locationService.GetLocationCount();
            ViewBag.testimonialCount = await _testimonialService.GetTestimonialCount();
            return View();
        }
    }
}