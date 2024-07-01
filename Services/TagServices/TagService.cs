using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperRealEstate.Context;
using DapperRealEstate.Dtos.TagDtos;

namespace DapperRealEstate.Services.TagServices
{
    public class TagService : ITagService
    {
        private readonly DbContext _dbContext;
        public TagService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateTagAsync(CreateTagDto createTagDto)
        {
            string query = "Insert Into Tag (TagName) values (@tagName)";
            var parameters = new DynamicParameters();
            parameters.Add("@tagName", createTagDto.TagName);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteTagAsync(int id)
        {
            string query = "Delete From Tag Where TagId=@tagId";
            var parameters = new DynamicParameters();
            parameters.Add("@tagId", id);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultTagDto>> GetAllTagAsync()
        {
            string query = "Select * From Tag";
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryAsync<ResultTagDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdTagDto> GetTagAsync(int id)
        {
            string query = "Select * From Tag Where TagId=@tagId";
            var parameters = new DynamicParameters();
            parameters.Add("@tagId", id);
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdTagDto>(query, parameters);
            return values;
        }

        public async Task UpdateTagAsync(UpdateTagDto updateTagDto)
        {
            string query = "Update Tag Set TagName=@tagName where TagId=@tagId";
            var parameters = new DynamicParameters();
            parameters.Add("@tagName", updateTagDto.TagName);
            parameters.Add("@tagId", updateTagDto.TagId);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}