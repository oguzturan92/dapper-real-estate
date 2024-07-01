using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperRealEstate.Dtos.AgentDtos
{
    public class CreateAgentDto
    {
        public string AgentFullname { get; set; }
        public string AgentTitle { get; set; }
        public string AgentImage { get; set; }
    }
}