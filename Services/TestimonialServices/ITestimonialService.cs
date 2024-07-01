using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Dtos.TestimonialDtos;

namespace DapperRealEstate.Services.TestimonialServices
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
        Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto);
        Task DeleteTestimonialAsync(int id);
        Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto);
        Task<GetByIdTestimonialDto> GetTestimonialAsync(int id);
        Task<int> GetTestimonialCount();
    }
}