using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperRealEstate.Dtos.TagDtos
{
    public class GetByIdTagDto
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
    }
}