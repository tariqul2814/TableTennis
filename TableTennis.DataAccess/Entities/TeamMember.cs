using System;
using System.Collections.Generic;
using System.Text;

namespace TableTennis.DataAccess.Entities
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string TeamMemberName { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
