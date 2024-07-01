using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperRealEstate.Dtos.TestimonialDtos
{
    public class CreateTestimonialDto
    {
        public string TestimonialFullname { get; set; }
        public string TestimonialDepartment { get; set; }
        public string TestimonialComment { get; set; }
        public string TestimonialImage { get; set; }
    }
}