using System;
using System.Collections.Generic;
using System.Text;

namespace TableTennis.DataAccess.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public int Point { get; set; }
        public ICollection<TeamMember> TeamMembers { get; set; }
        public ICollection<TeamMatch> TeamMatches { get; set; }
    }
}
