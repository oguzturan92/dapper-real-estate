using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperRealEstate.Dtos.LocationDtos
{
    public class UpdateLocationDto
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
}