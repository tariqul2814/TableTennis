using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TableTennis.DataAccess.DBContext;
using TableTennis.Services.TeamMatchService;

namespace TableTennis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMatch : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITeamMatchMasterService _teamMatchMasterService;
        public TeamMatch(ITeamMatchMasterService teamMatchMasterService, UserManager<ApplicationUser> userManager)
        {
            _teamMatchMasterService = teamMatchMasterService;
            _userManager = userManager;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetDayWiseTeamMatch()
        {
            return Ok(_teamMatchMasterService.GetAllTeamMatch());
        }

        [HttpGet("GetByTeamId")]
        public async Task<IActionResult> GetTeamMatchByTeamId(int TeamId)
        {
            return Ok(_teamMatchMasterService.GetTeamMatchesByTeamId(TeamId));
        }

        [HttpPut("Score")]
        public async Task<IActionResult> UpdateScore(int TeamMatchId,int TeamId, int Point)
        {
            if(_teamMatchMasterService.UpdateTeamMatchScore(TeamMatchId, TeamId, Point, User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return Ok(TeamId);
            }
            else
            {
                return BadRequest(TeamId);
            }
        }


    }
}
