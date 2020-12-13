using System;
using System.Collections.Generic;
using System.Text;
using TableTennis.DataAccess.UnitOfWork;
using TableTennis.DataAccess.Entities;
using TableTennis.Services.DTO.TeamMemberService;

namespace TableTennis.Services.TeamMemberService
{
    public class TeamMemberService
    {
        private readonly IUoW _uow;
        public TeamMemberService(IUoW uoW)
        {
            _uow = uoW;
        }
        
    }
    public interface ITeamMemberService
    {
        List<TeamMemberDTO> GetAllTeamMember();

        TeamMemberDTO GetByTeamMemberId(int TeamMemberId);

        bool UpdateTeamMember(TeamMemberDTO team);

        bool DeleteTeamMember(int TeamMemberId);

        bool CreateTeamMember(TeamMemberDTO teamMemberDTO);


    }
}
