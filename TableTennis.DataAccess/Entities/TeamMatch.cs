using System;
using System.Collections.Generic;
using System.Text;
using TableTennis.DataAccess.Entities.Common;

namespace TableTennis.DataAccess.Entities
{
    public class TeamMatch : AuditEntity
    {
        public int Id { get; set; }
        public List<TeamMatchMapping> TeamMatchMappings { get; set; }
        public Schedule Schedule { get; set; }
        public int ScheduleId { get; set; }
    }
}
