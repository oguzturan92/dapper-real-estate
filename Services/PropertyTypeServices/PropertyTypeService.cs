using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperRealEstate.Context;
using DapperRealEstate.Dtos.PropertyTypeDtos;

namespace DapperRealEstate.Services.PropertyTypeServices
{
    public class PropertyTypeService : IPropertyTypeService
    {
        private readonly DbContext _dbContext;
        public PropertyTypeService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreatePropertyTypeAsync(CreatePropertyTypeDto createPropertyTypeDto)
        {
            string query = "Insert Into PropertyType (PropertyTypeName) values (@propertyTypeName)";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyTypeName", createPropertyTypeDto.PropertyTypeName);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeletePropertyTypeAsync(int id)
        {
            string query = "Delete From PropertyType Where PropertyTypeId=@propertyTypeId";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyTypeId", id);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultPropertyTypeDto>> GetAllPropertyTypeAsync()
        {
            string query = "Select * From PropertyType";
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryAsync<ResultPropertyTypeDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdPropertyTypeDto> GetPropertyTypeAsync(int id)
        {
            string query = "Select * From PropertyType Where PropertyTypeId=@propertyTypeId";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyTypeId", id);
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdPropertyTypeDto>(query, parameters);
            return values;
        }

        public async Task UpdatePropertyTypeAsync(UpdatePropertyTypeDto updatePropertyTypeDto)
        {
            string query = "Update PropertyType Set PropertyTypeName=@propertyTypeName where PropertyTypeId=@propertyTypeId";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyTypeName", updatePropertyTypeDto.PropertyTypeName);
            parameters.Add("@propertyTypeId", updatePropertyTypeDto.PropertyTypeId);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}