using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Dtos.PropertyTypeDtos;
using DapperRealEstate.Services.PropertyTypeServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PropertyTypeController : Controller
    {
        private readonly IPropertyTypeService _propertyTypeService;
        public PropertyTypeController(IPropertyTypeService propertyTypeService)
        {
            _propertyTypeService = propertyTypeService;
        }

        public async Task<IActionResult> PropertyTypeList()
        {
            ViewBag.propertyTypeActive = "active";
            var values = await _propertyTypeService.GetAllPropertyTypeAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult PropertyTypeCreate()
        {
            ViewBag.propertyTypeActive = "active";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PropertyTypeCreate(CreatePropertyTypeDto createPropertyTypeDto)
        {
            await _propertyTypeService.CreatePropertyTypeAsync(createPropertyTypeDto);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("PropertyTypeList", "PropertyType");
        }

        [HttpGet]
        public async Task<IActionResult> PropertyTypeUpdate(int id)
        {
            ViewBag.propertyTypeActive = "active";
            var value = await _propertyTypeService.GetPropertyTypeAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> PropertyTypeUpdate(UpdatePropertyTypeDto updatePropertyTypeDto)
        {
            await _propertyTypeService.UpdatePropertyTypeAsync(updatePropertyTypeDto);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("PropertyTypeList", "PropertyType");
        }

        public async Task<IActionResult> PropertyTypeDelete(int id)
        {
            await _propertyTypeService.DeletePropertyTypeAsync(id);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("PropertyTypeList", "PropertyType");
        }
    }
}