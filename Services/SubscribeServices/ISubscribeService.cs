using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Dtos.SubscribeDtos;

namespace DapperRealEstate.Services.SubscribeServices
{
    public interface ISubscribeService
    {
        Task<List<ResultSubscribeDto>> GetAllSubscribeAsync();
        Task CreateSubscribeAsync(CreateSubscribeDto createSubscribeDto);
        Task DeleteSubscribeAsync(int id);
    }
}