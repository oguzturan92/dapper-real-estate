using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperRealEstate.Dtos.PropertyTypeDtos
{
    public class UpdatePropertyTypeDto
    {
        public int PropertyTypeId { get; set; }
        public string PropertyTypeName { get; set; }
    }
}