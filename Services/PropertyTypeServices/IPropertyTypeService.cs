using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Dtos.PropertyTypeDtos;

namespace DapperRealEstate.Services.PropertyTypeServices
{
    public interface IPropertyTypeService
    {
        Task<List<ResultPropertyTypeDto>> GetAllPropertyTypeAsync();
        Task CreatePropertyTypeAsync(CreatePropertyTypeDto createPropertyTypeDto);
        Task DeletePropertyTypeAsync(int id);
        Task UpdatePropertyTypeAsync(UpdatePropertyTypeDto updatePropertyTypeDto);
        Task<GetByIdPropertyTypeDto> GetPropertyTypeAsync(int id);
    }
}