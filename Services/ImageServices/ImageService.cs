using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperRealEstate.Context;
using DapperRealEstate.Dtos.ImageDtos;

namespace DapperRealEstate.Services.ImageServices
{
    public class ImageService : IImageService
    {
        private readonly DbContext _dbContext;
        public ImageService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateImageAsync(CreateImageDto createImageDto)
        {
            string query = "Insert Into Image (ImageName, PropertyId) values (@imageName, @propertyId)";
            var parameters = new DynamicParameters();
            parameters.Add("@imageName", createImageDto.ImageName);
            parameters.Add("@propertyId", createImageDto.PropertyId);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteImageAsync(int id)
        {
            string query = "Delete From Image Where ImageId=@imageId";
            var parameters = new DynamicParameters();
            parameters.Add("@imageId", id);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultImageDto>> GetAllImageAsync(int propertyId)
        {
            string query = "Select * From Image Where PropertyId=@propertyId";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyId", propertyId);
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryAsync<ResultImageDto>(query, parameters);
            return values.ToList();
        }

        public async Task<GetByIdImageDto> GetImageAsync(int id)
        {
            string query = "Select * From Image Where ImageId=@imageId";
            var parameters = new DynamicParameters();
            parameters.Add("@imageId", id);
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdImageDto>(query, parameters);
            return values;
        }

        public async Task UpdateImageAsync(UpdateImageDto updateImageDto)
        {
            string query = "Update Image Set ImageName=@imageName, PropertyId=@propertyId where ImageId=@imageId";
            var parameters = new DynamicParameters();
            parameters.Add("@imageId", updateImageDto.ImageId);
            parameters.Add("@imageName", updateImageDto.ImageName);
            parameters.Add("@propertyId", updateImageDto.PropertyId);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}