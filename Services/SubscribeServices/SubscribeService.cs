using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Context;
using DapperRealEstate.Dtos.SubscribeDtos;

namespace DapperRealEstate.Services.SubscribeServices
{
    public class SubscribeService : ISubscribeService
    {
        private readonly DbContext _dbContext;
        public SubscribeService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateSubscribeAsync(CreateSubscribeDto createSubscribeDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSubscribeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultSubscribeDto>> GetAllSubscribeAsync()
        {
            throw new NotImplementedException();
        }
    }
}