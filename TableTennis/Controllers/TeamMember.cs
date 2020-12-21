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
using TableTennis.Services.DTO.TeamMemberService;
using TableTennis.Services.DTO.TeamService;
using TableTennis.Services.TeamMemberService;

namespace TableTennis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin")]
    public class TeamMember : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITeamMemberService _teamMemberService;
        public TeamMember(ITeamMemberService teamMemberService, UserManager<ApplicationUser> userManager)
        {
            _teamMemberService = teamMemberService;
            _userManager = userManager;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateTeamMember(TeamMemberDTO teamMember)
        {
            if (_teamMemberService.CreateOrUpdateTeamMember(teamMember, User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return Ok(teamMember);
            }
            else
            {
                return BadRequest(teamMember);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateTeamMember(TeamMemberDTO teamMember)
        {
            if (_teamMemberService.CreateOrUpdateTeamMember(teamMember, User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return Ok(teamMember);
            }
            else
            {
                return BadRequest(teamMember);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteTeamMember(int TeamMemberId)
        {
            if (_teamMemberService.DeleteTeamMember(TeamMemberId, User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return Ok(TeamMemberId);
            }
            else
            {
                return BadRequest(TeamMemberId);
            }
        }

        [HttpGet("TeamById")]
        public async Task<IActionResult> GetTeamMemberById(int TeamMemberId)
        {
            if (TeamMemberId > 0)
                return Ok(_teamMemberService.GetByTeamMemberId(TeamMemberId));
            else
            {
                return BadRequest(TeamMemberId);
            }
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllTeamMember()
        {
            return Ok(_teamMemberService.GetAllTeamMember());
        }


    }
}
