using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Dtos.LocationDtos;

namespace DapperRealEstate.Services.LocationServices
{
    public interface ILocationService
    {
        Task<List<ResultLocationDto>> GetAllLocationAsync();
        Task CreateLocationAsync(CreateLocationDto createLocationDto);
        Task DeleteLocationAsync(int id);
        Task UpdateLocationAsync(UpdateLocationDto updateLocationDto);
        Task<GetByIdLocationDto> GetLocationAsync(int id);
        Task<int> GetLocationCount();
    }
}