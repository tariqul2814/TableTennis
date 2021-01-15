using System;
using System.Collections.Generic;
using System.Text;
using TableTennis.Services.DTO.ScheduleService;
using TableTennis.Services.DTO.TeamService;

namespace TableTennis.Services.DTO.TeamMatchService
{
    public class TeamMatchMappingsDTO
    {
        public int Id { get; set; }
        public int TeamMatchId { get; set; }
        public TeamMatchDTO TeamMatch { get; set; }

        public TeamDTO Team { get; set; }

        public int TeamId { get; set; }
        public int Point { get; set; }
    }
}
