using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperRealEstate.Dtos.PropertyDtos
{
    public class GetByIdPropertyDto
    {
        public int PropertyId { get; set; }
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
        public string AgentFullname { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int PropertyTypeId { get; set; }
        public string PropertyTypeName { get; set; }
        // public int TagId { get; set; }
        // public string TagName { get; set; }
        public string TagNames { get; set; }
        public string TagIds { get; set; }
        public string TagCount { get; set; }
        public List<int> SelectedTags { get; set; }
    }
}