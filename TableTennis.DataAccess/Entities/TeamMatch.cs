using System;
using System.Collections.Generic;
using System.Text;
using TableTennis.DataAccess.Entities.Common;

namespace TableTennis.DataAccess.Entities
{
    public class TeamMatch : AuditEntity
    {
        public int Id { get; set; }
        public int Point { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public Schedule Schedule { get; set; }
        public int ScheduleId { get; set; }
    }
}
