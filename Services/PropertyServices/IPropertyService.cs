using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Dtos.PropertyDtos;

namespace DapperRealEstate.Services.PropertyServices
{
    public interface IPropertyService
    {
        Task<List<ResultPropertyDto>> GetAllPropertyAsync();
        Task CreatePropertyAsync(CreatePropertyDto createPropertyDto, int[] selectTags);
        Task DeletePropertyAsync(int id);
        Task UpdatePropertyAsync(UpdatePropertyDto updatePropertyDto, int[] selectTags);
        Task<GetByIdPropertyDto> GetPropertyAsync(int id);
        Task<GetDetailPropertyDto> GetDetailPropertyAsync(int id);
        Task<GetDetailImagePropertyDto> GetDetailImagePropertyAsync(int id);
        Task<int> GetPropertyCount();
        Task<List<ResultSliderPropertyDto>> GetSliderTruePropertyAsync();
        Task<List<ResultHomePropertyDto>> GetRecentPropertyAsync();
        Task<List<ResultHomePropertyDto>> GetLast4PropertyAsync();
        Task<List<ResultHomePropertyDto>> GetListPropertyAsync(int skip, int take);
        Task<List<ResultHomePropertyDto>> GetListSearchPropertyAsync(string q, int location, float minPrice, float maxPrice);
        Task<float> GetPropertyMaxPrice();
        Task<float> GetPropertyMinPrice();
    }
}