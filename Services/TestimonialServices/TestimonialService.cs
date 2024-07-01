using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperRealEstate.Context;
using DapperRealEstate.Dtos.TestimonialDtos;

namespace DapperRealEstate.Services.TestimonialServices
{
    public class TestimonialService : ITestimonialService
    {
        private readonly DbContext _dbContext;
        public TestimonialService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto)
        {
            string query = "Insert Into Testimonial (TestimonialFullname, TestimonialDepartment, TestimonialComment, TestimonialImage) values (@testimonialFullname, @testimonialDepartment, @testimonialComment, @testimonialImage)";
            var parameters = new DynamicParameters();
            parameters.Add("@testimonialFullname", createTestimonialDto.TestimonialFullname);
            parameters.Add("@testimonialDepartment", createTestimonialDto.TestimonialDepartment);
            parameters.Add("@testimonialComment", createTestimonialDto.TestimonialComment);
            parameters.Add("@testimonialImage", createTestimonialDto.TestimonialImage);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteTestimonialAsync(int id)
        {
            string query = "Delete From Testimonial Where TestimonialId=@testimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@testimonialId", id);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<GetByIdTestimonialDto> GetTestimonialAsync(int id)
        {
            string query = "Select * From Testimonial Where TestimonialId=@testimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@testimonialId", id);
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdTestimonialDto>(query, parameters);
            return values;
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
            string query = "Select * From Testimonial";
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryAsync<ResultTestimonialDto>(query);
            return values.ToList();
        }

        public async Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto)
        {
            string query = "Update Testimonial Set TestimonialFullname=@testimonialFullname, TestimonialDepartment=@testimonialDepartment, TestimonialComment=@testimonialComment, TestimonialImage=@testimonialImage where TestimonialId=@testimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@testimonialId", updateTestimonialDto.TestimonialId);
            parameters.Add("@testimonialFullname", updateTestimonialDto.TestimonialFullname);
            parameters.Add("@testimonialDepartment", updateTestimonialDto.TestimonialDepartment);
            parameters.Add("@testimonialComment", updateTestimonialDto.TestimonialComment);
            parameters.Add("@testimonialImage", updateTestimonialDto.TestimonialImage);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<int> GetTestimonialCount()
        {
            string query = "Select Count(*) From Testimonial";
            var connection = _dbContext.CreateConnection();
            var value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }
    }
}