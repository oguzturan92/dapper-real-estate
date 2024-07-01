using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Dtos.TagDtos;
using DapperRealEstate.Services.TagServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IActionResult> TagList()
        {
            ViewBag.tagActive = "active";
            var values = await _tagService.GetAllTagAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult TagCreate()
        {
            ViewBag.tagActive = "active";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TagCreate(CreateTagDto createTagDto)
        {
            await _tagService.CreateTagAsync(createTagDto);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("TagList", "Tag");
        }

        [HttpGet]
        public async Task<IActionResult> TagUpdate(int id)
        {
            ViewBag.tagActive = "active";
            var value = await _tagService.GetTagAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> TagUpdate(UpdateTagDto updateTagDto)
        {
            await _tagService.UpdateTagAsync(updateTagDto);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("TagList", "Tag");
        }

        public async Task<IActionResult> TagDelete(int id)
        {
            await _tagService.DeleteTagAsync(id);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("TagList", "Tag");
        }
    }
}