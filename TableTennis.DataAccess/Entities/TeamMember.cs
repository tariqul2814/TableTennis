using System;
using System.Collections.Generic;
using System.Text;
using TableTennis.DataAccess.Entities.Common;

namespace TableTennis.DataAccess.Entities
{
    public class TeamMember : AuditEntity
    {
        public int Id { get; set; }
        public string TeamMemberName { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
