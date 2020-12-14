using System;
using System.Collections.Generic;
using System.Text;
using TableTennis.DataAccess.UnitOfWork;
using TableTennis.DataAccess.Entities;
using TableTennis.Services.DTO.TeamMemberService;
using System.Linq;

namespace TableTennis.Services.TeamMemberService
{
    public class TeamMemberService
    {
        private readonly IUoW _uow;
        public TeamMemberService(IUoW uoW)
        {
            _uow = uoW;
        }

        public List<TeamMember> GetAllTeamMember()
        {
            return _uow.TeamMemberRepository.Get(x=> x.IsRemove == false).Select(x => new TeamMember {
                        Id = x.Id,
                        Team = x.Team,
                        TeamId = x.TeamId,
                        TeamMemberName = x.TeamMemberName
                    }).ToList();
        }

        public TeamMember GetByTeamMemberId(int TeamMemberId)
        {
            return _uow.TeamMemberRepository.Get(x => x.IsRemove == false && x.Id == TeamMemberId).
             Select(x=> new TeamMember {
                        Id = x.Id,
                        Team = x.Team,
                        TeamId = x.TeamId,
                        TeamMemberName = x.TeamMemberName
             }).FirstOrDefault();
        }

        public bool CreateOrUpdateTeamMember(TeamMemberDTO teamMemberInsert, string UserId)
        {
            if(teamMemberInsert.Id>0)
            {
                var TeamMember = new TeamMember
                {
                    Id = teamMemberInsert.Id,
                    IsRemove = false,
                    Team = _uow.TeamRepository.Get(x=> x.Id == teamMemberInsert.TeamId && !x.IsRemove).FirstOrDefault(),
                    TeamId = teamMemberInsert.TeamId,
                    TeamMemberName = teamMemberInsert.TeamMemberName,
                    ModifiedBy = UserId,
                    ModifiedDate = DateTime.Now
                };
            }
            else
            {
                var checkTotalMemberInTeam = _uow.TeamMemberRepository.Get(x => x.TeamId == teamMemberInsert.TeamId).ToList();

                if(checkTotalMemberInTeam.Count<3)
                {
                    var TeamMember = new TeamMember
                    {
                        IsRemove = false,
                        Team = _uow.TeamRepository.Get(x => x.Id == teamMemberInsert.TeamId && !x.IsRemove).FirstOrDefault(),
                        TeamId = teamMemberInsert.TeamId,
                        TeamMemberName = teamMemberInsert.TeamMemberName,
                        CreatedBy = UserId,
                        CreateDate = DateTime.Now
                    };

                    _uow.TeamMemberRepository.Insert(TeamMember);
                    _uow.TeamMemberRepository.Save();

                    return true;
                }

                else
                {
                    return false;
                }
            }
        }

        public bool DeleteTeamMember(int TeamMemberId)
        {
            var checkAvailability = _uow.TeamMemberRepository.Get(x=> x.Id == )
        }
    }
    public interface ITeamMemberService
    {
        List<TeamMemberDTO> GetAllTeamMember();

        TeamMemberDTO GetByTeamMemberId(int TeamMemberId);

        bool CreateOrUpdateTeamMember(TeamMemberDTO team);

        bool DeleteTeamMember(int TeamMemberId);

    }
}
