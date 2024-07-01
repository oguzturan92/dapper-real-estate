using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperRealEstate.Dtos.PropertyDtos
{
    public class GetDetailImagePropertyDto
    {
        public int PropertyId { get; set; }
        public string ImageName { get; set; }
        public string ImageCount { get; set; }
    }
}