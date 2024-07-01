using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Dtos.AgentDtos;
using DapperRealEstate.Context;
using Dapper;

namespace DapperRealEstate.Services.AgentServices
{
    public class AgentService : IAgentService
    {
        private readonly DbContext _dbContext;
        public AgentService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAgentAsync(CreateAgentDto createAgentDto)
        {
            string query = "Insert Into Agent (AgentFullname, AgentTitle, AgentImage) values (@agentFullname, @agentTitle, @agentImage)";
            var parameters = new DynamicParameters();
            parameters.Add("@agentFullname", createAgentDto.AgentFullname);
            parameters.Add("@agentTitle", createAgentDto.AgentTitle);
            parameters.Add("@agentImage", createAgentDto.AgentImage);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAgentAsync(int id)
        {
            string query = "Delete From Agent Where AgentId=@agentId";
            var parameters = new DynamicParameters();
            parameters.Add("@agentId", id);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<GetByIdAgentDto> GetAgentAsync(int id)
        {
            string query = "Select * From Agent Where AgentId=@agentId";
            var parameters = new DynamicParameters();
            parameters.Add("@agentId", id);
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdAgentDto>(query, parameters);
            return values;
        }

        public async Task<List<ResultAgentDto>> GetAllAgentAsync()
        {
            string query = "Select * From Agent";
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryAsync<ResultAgentDto>(query);
            return values.ToList();
        }

        public async Task UpdateAgentAsync(UpdateAgentDto updateAgentDto)
        {
            string query = "Update Agent Set AgentFullname=@agentFullname, AgentTitle=@agentTitle, AgentImage=@agentImage where AgentId=@agentId";
            var parameters = new DynamicParameters();
            parameters.Add("@agentId", updateAgentDto.AgentId);
            parameters.Add("@agentFullname", updateAgentDto.AgentFullname);
            parameters.Add("@agentTitle", updateAgentDto.AgentTitle);
            parameters.Add("@agentImage", updateAgentDto.AgentImage);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<int> GetAgentCount()
        {
            string query = "Select Count(*) From Agent";
            var connection = _dbContext.CreateConnection();
            var value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }
    }
}