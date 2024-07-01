using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Services.PropertyServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.ViewComponents.List
{
    public class ListViewComponent : ViewComponent
    {
        private readonly IPropertyService _propertyService;
        public ListViewComponent(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string q, int location, float minPrice, float maxPrice, int page)
        {
            if (!string.IsNullOrEmpty(q) || location > 0 || minPrice > 0 || maxPrice > 0)
            {
                if (q==null)
                {
                    q="";
                }

                if (minPrice == 0)
                {
                    minPrice=await _propertyService.GetPropertyMinPrice();
                }
                if (maxPrice == 0)
                {
                    maxPrice=await _propertyService.GetPropertyMaxPrice();
                }

                var valuesSearch = await _propertyService.GetListSearchPropertyAsync(q, location, minPrice, maxPrice);
                return View(valuesSearch);
            }
            
            int take = 9;
            int skip = (page - 1) * take;
            int propertyCount = await _propertyService.GetPropertyCount();
            ViewBag.thisPage = page;
            ViewBag.totalPage = (int)Math.Ceiling((decimal)propertyCount/take);

            var values = await _propertyService.GetListPropertyAsync(skip, take);
            return View(values);
        }
    }
}