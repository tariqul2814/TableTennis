using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableTennis.DataAccess.DBContext;
using TableTennis.Services.ScheduleService;
using TableTennis.Services.TeamMatchService;

namespace TableTennis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Schedule : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IScheduleMasterService _scheduleMasterService;
        public Schedule(IScheduleMasterService scheduleMasterService, ITeamMatchMasterService teamMatchMasterService, UserManager<ApplicationUser> userManager)
        {
            _scheduleMasterService = scheduleMasterService;
            _userManager = userManager;
        }

        [HttpGet("Scheduling")]
        public async Task<IActionResult> AutoSchedulingTeamMatches()
        {
            return Ok();
        }
    }
}
