﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TableTennis.Services.ScheduleService
{
    public class ScheduleMasterService : IScheduleMasterService
    {

    }
    public interface IScheduleMasterService
    {
        public List<ScheduleMasterService> GetAllScheduleWithAllInfo();

        public bool AutoSchedulingTeamMatches();
    }
}
