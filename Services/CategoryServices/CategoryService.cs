using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperRealEstate.Context;
using DapperRealEstate.Dtos.CategoryDtos;

namespace DapperRealEstate.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly DbContext _dbContext;
        public CategoryService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            string query = "Insert Into Category (CategoryName) values (@categoryName)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", createCategoryDto.CategoryName);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            string query = "Delete From Category Where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From Category";
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryAsync<ResultCategoryDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdCategoryDto> GetCategoryAsync(int id)
        {
            string query = "Select * From Category Where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, parameters);
            return values;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            string query = "Update Category Set CategoryName=@categoryName where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", updateCategoryDto.CategoryName);
            parameters.Add("@categoryId", updateCategoryDto.CategoryId);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<int> GetCategoryCount()
        {
            string query = "Select Count(*) From Category";
            var connection = _dbContext.CreateConnection();
            var value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        public async Task<List<ResultCategoryAndCountDto>> GetCategoryAndCount()
        {
            string query = "Select c.CategoryName, COUNT(p.PropertyId) As CategoryCount From Property p Left Join Category c On p.CategoryId = c.CategoryId Group By c.CategoryName";
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryAsync<ResultCategoryAndCountDto>(query);
            return values.ToList();
        }
    }
}