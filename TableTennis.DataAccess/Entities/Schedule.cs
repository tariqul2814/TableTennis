using System;
using System.Collections.Generic;
using System.Text;
using TableTennis.DataAccess.Entities.Common;

namespace TableTennis.DataAccess.Entities
{
    public class Schedule : AuditEntity
    {
        public int Id { get; set; }
        public DateTime MatchDate { get; set; }
        public ICollection<TeamMatch> TeamMatches { get; set; }
    }
}
