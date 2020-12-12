using System;
using System.Collections.Generic;
using System.Text;
using TableTennis.Services.DTO.TeamService;

namespace TableTennis.Services.DTO.TeamMemberService
{
    public class TeamMemberDTO
    {
        public int Id { get; set; }
        public string TeamMemberName { get; set; }
        public int TeamId { get; set; }
        public TeamDTO Team { get; set; }
    }
}
