using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Dtos.AgentDtos;

namespace DapperRealEstate.Services.AgentServices
{
    public interface IAgentService
    {
        Task<List<ResultAgentDto>> GetAllAgentAsync();
        Task CreateAgentAsync(CreateAgentDto createAgentDto);
        Task DeleteAgentAsync(int id);
        Task UpdateAgentAsync(UpdateAgentDto updateAgentDto);
        Task<GetByIdAgentDto> GetAgentAsync(int id);
        Task<int> GetAgentCount();
    }
}