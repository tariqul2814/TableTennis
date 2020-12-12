using System;
using System.Collections.Generic;
using System.Text;
using TableTennis.Services.DTO.TeamMatchService;

namespace TableTennis.Services.DTO.ScheduleService
{
    public class ScheduleDTO
    {
        public int Id { get; set; }
        public string MatchDay { get; set; }
        public ICollection<TeamMatchDTO> TeamMatches { get; set; }
    }
}
