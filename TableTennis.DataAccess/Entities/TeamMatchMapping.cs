using System;
using System.Collections.Generic;
using System.Text;
using TableTennis.DataAccess.Entities.Common;

namespace TableTennis.DataAccess.Entities
{
    public class TeamMatchMapping : AuditEntity
    {
        public int Id { get; set; }
        public int TeamMatchId { get; set; }
        public TeamMatch TeamMatch { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int Point { get; set; }
    }
}
