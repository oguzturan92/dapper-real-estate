using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperRealEstate.Dtos.TagDtos;

namespace DapperRealEstate.Services.TagServices
{
    public interface ITagService
    {
        Task<List<ResultTagDto>> GetAllTagAsync();
        Task CreateTagAsync(CreateTagDto createTagDto);
        Task DeleteTagAsync(int id);
        Task UpdateTagAsync(UpdateTagDto updateTagDto);
        Task<GetByIdTagDto> GetTagAsync(int id);
    }
}