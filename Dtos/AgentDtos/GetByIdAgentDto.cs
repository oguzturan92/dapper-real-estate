using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperRealEstate.Dtos.AgentDtos
{
    public class GetByIdAgentDto
    {
        public int AgentId { get; set; }
        public string AgentFullname { get; set; }
        public string AgentTitle { get; set; }
        public string AgentImage { get; set; }
    }
}