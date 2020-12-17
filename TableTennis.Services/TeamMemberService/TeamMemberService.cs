using System;
using System.Collections.Generic;
using System.Text;
using TableTennis.DataAccess.UnitOfWork;
using TableTennis.DataAccess.Entities;
using TableTennis.Services.DTO.TeamMemberService;
using System.Linq;

namespace TableTennis.Services.TeamMemberService
{
    public class TeamMemberService : ITeamMemberService
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
            try
            {
                if (teamMemberInsert.Id > 0)
                {
                    var checkAvailability = _uow.TeamMemberRepository.Get(x => x.Id == teamMemberInsert.Id && !x.IsRemove).FirstOrDefault();

                    if(checkAvailability==null)
                    {
                        return false;
                    }
                    else
                    {
                        var TeamMember = new TeamMember
                        {
                            IsRemove = false,
                            CreateDate = checkAvailability.CreateDate,
                            CreatedBy = checkAvailability.CreatedBy,
                            ModifiedBy = UserId,
                            ModifiedDate = DateTime.Now,
                            TeamMemberName = teamMemberInsert.TeamMemberName
                        };

                        _uow.TeamMemberRepository.Update(TeamMember);
                        _uow.Commit();
                        return true;
                    }
                }
                else
                {
                    var TeamMember = new TeamMember
                    {
                        IsRemove = false,
                        CreateDate = DateTime.Now,
                        CreatedBy = UserId,
                        TeamMemberName = teamMemberInsert.TeamMemberName
                    };
                    _uow.TeamMemberRepository.Insert(TeamMember);
                    _uow.Commit();
                    return true;
                }
            }
            catch(Exception er)
            {
                return false;
            }
        }

        public bool DeleteTeamMember(int TeamMemberId, string UserId)
        {
            var checkAvailability = _uow.TeamMemberRepository.Get(x => x.Id == TeamMemberId && !x.IsRemove).FirstOrDefault();
            if(checkAvailability!=null)
            {
                checkAvailability.IsRemove = false;
                checkAvailability.ModifiedBy = UserId;
                checkAvailability.Team = null;
                checkAvailability.TeamId = 0;
                _uow.TeamMemberRepository.Update(checkAvailability);
                _uow.Commit();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public interface ITeamMemberService
    {
        List<TeamMember> GetAllTeamMember();

        TeamMember GetByTeamMemberId(int TeamMemberId);

        bool CreateOrUpdateTeamMember(TeamMemberDTO team, string UserId);

        bool DeleteTeamMember(int TeamMemberId, string UserId);

    }
}
