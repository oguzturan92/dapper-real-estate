using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Dtos.LocationDtos;
using DapperRealEstate.Services.LocationServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<IActionResult> LocationList()
        {
            ViewBag.locationActive = "active";
            var values = await _locationService.GetAllLocationAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult LocationCreate()
        {
            ViewBag.locationActive = "active";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LocationCreate(CreateLocationDto createLocationDto)
        {
            await _locationService.CreateLocationAsync(createLocationDto);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("LocationList", "Location");
        }

        [HttpGet]
        public async Task<IActionResult> LocationUpdate(int id)
        {
            ViewBag.locationActive = "active";
            var value = await _locationService.GetLocationAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> LocationUpdate(UpdateLocationDto updateLocationDto)
        {
            await _locationService.UpdateLocationAsync(updateLocationDto);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("LocationList", "Location");
        }

        public async Task<IActionResult> LocationDelete(int id)
        {
            await _locationService.DeleteLocationAsync(id);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("LocationList", "Location");
        }
    }
}