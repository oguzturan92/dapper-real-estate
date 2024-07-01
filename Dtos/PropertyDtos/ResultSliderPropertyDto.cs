using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperRealEstate.Dtos.PropertyDtos
{
    public class ResultSliderPropertyDto
    {
        public int PropertyId { get; set; }
        public string PropertyTitle { get; set; }
        public string PropertySubTitle { get; set; }
        public string PropertyAddress { get; set; }
        public float PropertyPrice { get; set; }
        public string PropertySliderImage { get; set; }
        public string LocationName { get; set; }
    }
}