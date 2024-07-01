using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Dtos.ImageDtos;

namespace DapperRealEstate.Services.ImageServices
{
    public interface IImageService
    {
        Task<List<ResultImageDto>> GetAllImageAsync(int propertyId);
        Task CreateImageAsync(CreateImageDto createImageDto);
        Task DeleteImageAsync(int id);
        Task UpdateImageAsync(UpdateImageDto updateImageDto);
        Task<GetByIdImageDto> GetImageAsync(int id);
    }
}