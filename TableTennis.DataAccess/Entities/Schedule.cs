using System;
using System.Collections.Generic;
using System.Text;

namespace TableTennis.DataAccess.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime MatchDate { get; set; }
        public ICollection<TeamMatch> TeamMatches { get; set; }
    }
}
