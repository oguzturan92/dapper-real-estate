using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperRealEstate.Dtos.PropertyDtos
{
    public class ResultHomePropertyDto
    {
        public int PropertyId { get; set; }
        public string PropertyTitle { get; set; }
        public string PropertySubTitle { get; set; }
        public string ImageName { get; set; }
        public float PropertyPrice { get; set; }
        public bool PropertySell { get; set; }
        public string CategoryName { get; set; }
        public string LocationName { get; set; }
        public string PropertyTypeName { get; set; }
    }
}