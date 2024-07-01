using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Services.CategoryServices;
using DapperRealEstate.Services.PropertyServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.ViewComponents.Detail
{
    public class DetailViewComponent : ViewComponent
    {
        private readonly IPropertyService _propertyService;
        private readonly ICategoryService _categoryService;
        public DetailViewComponent(IPropertyService propertyService, ICategoryService categoryService)
        {
            _propertyService = propertyService;
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = await _propertyService.GetDetailPropertyAsync(id);
            ViewBag.detailImage = await _propertyService.GetDetailImagePropertyAsync(id);
            ViewBag.categoryAndCount = await _categoryService.GetCategoryAndCount();
            ViewBag.last4Post = await _propertyService.GetLast4PropertyAsync();
            return View(values);
        }
    }
}