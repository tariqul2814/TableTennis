using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TableTennis.DataAccess.DBContext;
using TableTennis.Services.DTO.TeamService;
using TableTennis.Services.TeamService;

namespace TableTennis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin")]
    public class Team : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITeamMasterService _teamMasterService;
        public Team(ITeamMasterService teamMasterService, UserManager<ApplicationUser> userManager)
        {
            _teamMasterService = teamMasterService;
            _userManager = userManager;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateTeam(TeamDTO team)
        {
            if(_teamMasterService.CreateOrUpdateTeam(team, User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return Ok(team);
            }
            else
            {
                return BadRequest(team);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateTeam(TeamDTO team)
        {
            if (_teamMasterService.CreateOrUpdateTeam(team, User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return Ok(team);
            }
            else
            {
                return BadRequest(team);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteTeam(int TeamId)
        {
            if (_teamMasterService.DeleteTeam(TeamId, User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return Ok(TeamId);
            }
            else
            {
                return BadRequest(TeamId);
            }
        }

        [HttpGet("TeamById")]
        public async Task<IActionResult> GetTeamById(int TeamId)
        {
            if(TeamId>0)
            return Ok(_teamMasterService.GetTeamById(TeamId));
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllTeam()
        {
            return Ok(_teamMasterService.GetAllTeam());
        }

        [HttpGet("AddTeamMember")]
        public async Task<IActionResult> AddTeamMemberFromTeam(int TeamId, int TeamMemberId)
        {
            if (_teamMasterService.AddTeamMemberIntoTeam(TeamId, TeamMemberId, User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("RemoveTeamMember")]
        public async Task<IActionResult> RemoveTeamMemberFromTeam(int TeamId, int TeamMemberId)
        {
            if (_teamMasterService.RemoveTeamMemberFromTeam(TeamId, TeamMemberId, User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
