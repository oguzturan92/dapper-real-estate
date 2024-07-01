using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Dtos.CategoryDtos;

namespace DapperRealEstate.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task DeleteCategoryAsync(int id);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<GetByIdCategoryDto> GetCategoryAsync(int id);
        Task<int> GetCategoryCount();
        Task<List<ResultCategoryAndCountDto>> GetCategoryAndCount();
    }
}