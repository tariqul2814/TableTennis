using System;
using System.Collections.Generic;
using System.Text;
using TableTennis.Services.DTO.TeamService;
using TableTennis.Services.DTO.ScheduleService;

namespace TableTennis.Services.DTO.TeamMatchService
{
    public class TeamMatchDTO
    {
        public int Id { get; set; }
        public List<TeamMatchMappingsDTO> TeamMatchMappings { get; set; }
        public ScheduleDTO Schedule { get; set; }
        public int ScheduleId { get; set; }
    }
}
