using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperRealEstate.Context;
using DapperRealEstate.Dtos.LocationDtos;

namespace DapperRealEstate.Services.LocationServices
{
    public class LocationService : ILocationService
    {
        private readonly DbContext _dbContext;
        public LocationService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateLocationAsync(CreateLocationDto createLocationDto)
        {
            string query = "Insert Into Location (LocationName) values (@locationName)";
            var parameters = new DynamicParameters();
            parameters.Add("@locationName", createLocationDto.LocationName);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteLocationAsync(int id)
        {
            string query = "Delete From Location Where LocationId=@locationId";
            var parameters = new DynamicParameters();
            parameters.Add("@locationId", id);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultLocationDto>> GetAllLocationAsync()
        {
            string query = "Select * From Location";
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryAsync<ResultLocationDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdLocationDto> GetLocationAsync(int id)
        {
            string query = "Select * From Location Where LocationId=@locationId";
            var parameters = new DynamicParameters();
            parameters.Add("@locationId", id);
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdLocationDto>(query, parameters);
            return values;
        }

        public async Task UpdateLocationAsync(UpdateLocationDto updateLocationDto)
        {
            string query = "Update Location Set LocationName=@locationName where LocationId=@locationId";
            var parameters = new DynamicParameters();
            parameters.Add("@locationName", updateLocationDto.LocationName);
            parameters.Add("@locationId", updateLocationDto.LocationId);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<int> GetLocationCount()
        {
            string query = "Select Count(*) From Location";
            var connection = _dbContext.CreateConnection();
            var value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }
    }
}