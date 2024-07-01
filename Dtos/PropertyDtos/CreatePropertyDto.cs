using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperRealEstate.Dtos.PropertyDtos
{
    public class CreatePropertyDto
    {
        public string PropertyTitle { get; set; }
        public string PropertySubTitle { get; set; }
        public string PropertyDescription { get; set; }
        public string PropertyAddress { get; set; }
        public string PropertyEmbed { get; set; }
        public DateTime PropertyDate { get; set; }
        public float PropertyPrice { get; set; }
        public bool PropertySlider { get; set; }
        public string PropertySliderImage { get; set; }
        public bool PropertyHome { get; set; }
        public bool PropertySell { get; set; }

        // İlişkiler
        public int AgentId { get; set; }
        public int CategoryId { get; set; }
        public int LocationId { get; set; }
        public int PropertyTypeId { get; set; }
        public int[] TagIds { get; set; }
    }
}