using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Dtos.TestimonialDtos;
using DapperRealEstate.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IActionResult> TestimonialList()
        {
            ViewBag.testimonialActive = "active";
            var values = await _testimonialService.GetAllTestimonialAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult TestimonialCreate()
        {
            ViewBag.testimonialActive = "active";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TestimonialCreate(CreateTestimonialDto createTestimonialDto)
        {
            await _testimonialService.CreateTestimonialAsync(createTestimonialDto);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("TestimonialList", "Testimonial");
        }

        [HttpGet]
        public async Task<IActionResult> TestimonialUpdate(int id)
        {
            ViewBag.testimonialActive = "active";
            var value = await _testimonialService.GetTestimonialAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> TestimonialUpdate(UpdateTestimonialDto updateTestimonialDto)
        {
            await _testimonialService.UpdateTestimonialAsync(updateTestimonialDto);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("TestimonialList", "Testimonial");
        }

        public async Task<IActionResult> TestimonialDelete(int id)
        {
            await _testimonialService.DeleteTestimonialAsync(id);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("TestimonialList", "Testimonial");
        }
    }
}