using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Dtos.PropertyDtos;
using DapperRealEstate.Services.AgentServices;
using DapperRealEstate.Services.CategoryServices;
using DapperRealEstate.Services.LocationServices;
using DapperRealEstate.Services.PropertyServices;
using DapperRealEstate.Services.PropertyTypeServices;
using DapperRealEstate.Services.TagServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PropertyController : Controller
    {
        private readonly IPropertyService _propertyService;
        private readonly ITagService _tagService;
        private readonly IAgentService _agentService;
        private readonly ICategoryService _categoryService;
        private readonly ILocationService _locationService;
        private readonly IPropertyTypeService _propertyTypeService;
        public PropertyController(IPropertyService propertyService, ITagService tagService, IAgentService agentService, ICategoryService categoryService, ILocationService locationService, IPropertyTypeService propertyTypeService)
        {
            _propertyService = propertyService;
            _tagService = tagService;
            _agentService = agentService;
            _categoryService = categoryService;
            _locationService = locationService;
            _propertyTypeService = propertyTypeService;
        }

        public async Task<IActionResult> PropertyList()
        {
            ViewBag.propertyActive = "active";
            var values = await _propertyService.GetAllPropertyAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> PropertyCreate()
        {
            ViewBag.propertyActive = "active";
            ViewBag.tags = await _tagService.GetAllTagAsync();
            ViewBag.agents = await _agentService.GetAllAgentAsync();
            ViewBag.categories = await _categoryService.GetAllCategoryAsync();
            ViewBag.locations = await _locationService.GetAllLocationAsync();
            ViewBag.propertyTypes = await _propertyTypeService.GetAllPropertyTypeAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PropertyCreate(CreatePropertyDto createPropertyDto, int[] selectTags)
        {
            createPropertyDto.PropertyDate = DateTime.Now;
            await _propertyService.CreatePropertyAsync(createPropertyDto, selectTags);

            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("PropertyList", "Property");
        }

        [HttpGet]
        public async Task<IActionResult> PropertyUpdate(int id)
        {
            ViewBag.propertyActive = "active";
            ViewBag.tags = await _tagService.GetAllTagAsync();
            ViewBag.agents = await _agentService.GetAllAgentAsync();
            ViewBag.categories = await _categoryService.GetAllCategoryAsync();
            ViewBag.locations = await _locationService.GetAllLocationAsync();
            ViewBag.propertyTypes = await _propertyTypeService.GetAllPropertyTypeAsync();
            var value = await _propertyService.GetPropertyAsync(id);

            List<int> selectedTagIds = new List<int>();
            if (!string.IsNullOrEmpty(value.TagCount))
            {
                for (int i = 0; i < Int32.Parse(value.TagCount); i++)
                {
                    var tagId = value.TagIds.Split()[i];
                    selectedTagIds.Add(Int32.Parse(tagId));
                }
            }
            value.SelectedTags = selectedTagIds;

            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> PropertyUpdate(UpdatePropertyDto updatePropertyDto, int[] selectTags)
        {
            Console.WriteLine();
            await _propertyService.UpdatePropertyAsync(updatePropertyDto, selectTags);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("PropertyList", "Property");
        }

        public async Task<IActionResult> PropertyDelete(int id)
        {
            await _propertyService.DeletePropertyAsync(id);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("PropertyList", "Property");
        }
    }
}