using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Dtos.CategoryDtos;
using DapperRealEstate.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> CategoryList()
        {
            ViewBag.categoryActive = "active";
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CategoryCreate()
        {
            ViewBag.categoryActive = "active";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CategoryCreate(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("CategoryList", "Category");
        }

        [HttpGet]
        public async Task<IActionResult> CategoryUpdate(int id)
        {
            ViewBag.categoryActive = "active";
            var value = await _categoryService.GetCategoryAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> CategoryUpdate(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("CategoryList", "Category");
        }

        public async Task<IActionResult> CategoryDelete(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("CategoryList", "Category");
        }
    }
}