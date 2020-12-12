using System;
using System.Collections.Generic;
using System.Text;
using TableTennis.DataAccess.Entities;
using TableTennis.Services.DTO.TeamMatchService;
using TableTennis.Services.DTO.TeamMemberService;

namespace TableTennis.Services.DTO.TeamService
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public int Point { get; set; }
        public ICollection<TeamMemberDTO> TeamMembers { get; set; }
        public ICollection<TeamMatchDTO> TeamMatches { get; set; }
    }
}
