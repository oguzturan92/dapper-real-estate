using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperRealEstate.Dtos.ImageDtos
{
    public class CreateImageDto
    {
        public string ImageName { get; set; }
        public int PropertyId { get; set; }
    }
}