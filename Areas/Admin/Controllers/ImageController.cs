using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Dtos.ImageDtos;
using DapperRealEstate.Services.ImageServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;
        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public async Task<IActionResult> ImageList(int propertyId)
        {
            ViewBag.imageActive = "active";
            ViewBag.propertyId = propertyId;
            var values = await _imageService.GetAllImageAsync(propertyId);
            return View(values);
        }

        [HttpGet]
        public IActionResult ImageCreate(int propertyId)
        {
            ViewBag.imageActive = "active";
            ViewBag.propertyId = propertyId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ImageCreate(CreateImageDto createImageDto)
        {
            await _imageService.CreateImageAsync(createImageDto);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("ImageList", "Image", new { propertyId = createImageDto.PropertyId});
        }

        [HttpGet]
        public async Task<IActionResult> ImageUpdate(int id)
        {
            ViewBag.imageActive = "active";
            var value = await _imageService.GetImageAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> ImageUpdate(UpdateImageDto updateImageDto)
        {
            await _imageService.UpdateImageAsync(updateImageDto);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("ImageList", "Image", new { propertyId = updateImageDto.PropertyId});
        }

        public async Task<IActionResult> ImageDelete(int id, int propertyId)
        {
            await _imageService.DeleteImageAsync(id);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("ImageList", "Image", new { propertyId = propertyId});
        }
    }
}