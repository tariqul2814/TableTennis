using System;
using System.Collections.Generic;
using System.Text;
using TableTennis.DataAccess.Entities.Common;

namespace TableTennis.DataAccess.Entities
{
    public class Team : AuditEntity
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public int Point { get; set; }
        public ICollection<TeamMember> TeamMembers { get; set; }
        public ICollection<TeamMatch> TeamMatches { get; set; }
    }
}
