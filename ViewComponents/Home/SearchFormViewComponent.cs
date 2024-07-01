using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Services.LocationServices;
using DapperRealEstate.Services.PropertyServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.ViewComponents.Home
{
    public class SearchFormViewComponent : ViewComponent
    {
        private readonly ILocationService _locationService;
        private readonly IPropertyService _propertyService;
        public SearchFormViewComponent(ILocationService locationService, IPropertyService propertyService)
        {
            _locationService = locationService;
            _propertyService = propertyService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _locationService.GetAllLocationAsync();
            var maxPrice = await _propertyService.GetPropertyMaxPrice();
            var minPrice = await _propertyService.GetPropertyMinPrice();

            var fark = maxPrice-minPrice;
            var kademe = fark/10;
            
            // Fiyatı en düşük ilan fiyatı ve basamaklarına ayırma - Searc formunda en düşük fiyat seçeneğinde listelemek için
            List<float> minPrices = new List<float>();
            minPrices.Add(minPrice);
            for (int i = 0; i < 5; i++)
            {
                minPrice += kademe;
                minPrices.Add(minPrice);
            }

            // Fiyatı en yüksek ilan fiyatı ve basamaklarına ayırma - Searc formunda en yüksek fiyat seçeneğinde listelemek için
            List<float> maxPrices = new List<float>();
            maxPrices.Add(maxPrice);
            for (int i = 0; i < 5; i++)
            {
                maxPrice -= kademe;
                maxPrices.Add(maxPrice);
            }

            ViewBag.minPriceSelect = minPrices;
            ViewBag.maxPriceSelect = maxPrices;

            return View(values);
        }
    }
}