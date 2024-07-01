using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperRealEstate.Dtos.LocationDtos
{
    public class GetByIdLocationDto
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
}