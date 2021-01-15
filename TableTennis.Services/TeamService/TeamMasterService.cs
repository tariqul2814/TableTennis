using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TableTennis.DataAccess.Entities;
using TableTennis.DataAccess.UnitOfWork;
using TableTennis.Services.DTO.ScheduleService;
using TableTennis.Services.DTO.TeamMatchService;
using TableTennis.Services.DTO.TeamMemberService;
using TableTennis.Services.DTO.TeamService;

namespace TableTennis.Services.TeamService
{
    public class TeamMasterService : ITeamMasterService
    {
        private readonly IUoW uow;
        public TeamMasterService(IUoW _uow)
        {
            uow = _uow;
        }

        public TeamDTO GetTeamById(int TeamId)
        {
            return uow.TeamRepository.Get(x => x.IsRemove == false && x.Id == TeamId).Select(
                    y=> new TeamDTO
                    {
                        Id = y.Id,
                        TeamName = y.TeamName

                    }).FirstOrDefault();
        }

        public List<TeamDTO> GetAllTeam()
        {
            return uow.TeamRepository.Get(x=> x.IsRemove!=false).Select(
                    y=> new TeamDTO
                    {
                        Id = y.Id,
                        TeamName = y.TeamName
                    }
                ).ToList();
        }

        public bool CreateOrUpdateTeam(TeamDTO team, string UserId)
        {
            try
            {
                if (team.Id > 0)
                {
                    var checkAvailableTeam = uow.TeamRepository.Get(x => x.Id == team.Id && !x.IsRemove).FirstOrDefault();
                    var checkAvailabilityName = uow.TeamRepository.Get(x => x.TeamName == team.TeamName && !x.IsRemove).FirstOrDefault();

                    if (checkAvailabilityName != null && checkAvailableTeam != null && checkAvailabilityName.Id == team.Id)
                    {
                        var InsertTeam = new Team
                        {
                            Id = team.Id,
                            TeamName = team.TeamName,
                            CreateDate = checkAvailableTeam.CreateDate,
                            CreatedBy = checkAvailableTeam.CreatedBy,
                            IsRemove = false,
                            ModifiedBy = UserId,
                            ModifiedDate = DateTime.Now,
                            TeamMatchMappings = checkAvailableTeam.TeamMatchMappings,
                            TeamMembers = checkAvailableTeam.TeamMembers
                        };

                        uow.TeamRepository.Update(InsertTeam);
                        uow.Commit();
                        return true;

                    }
                    else if (checkAvailabilityName == null && checkAvailableTeam != null)
                    {
                        var InsertTeam = new Team
                        {
                            Id = team.Id,
                            TeamName = team.TeamName,
                            CreateDate = checkAvailableTeam.CreateDate,
                            CreatedBy = checkAvailableTeam.CreatedBy,
                            IsRemove = false,
                            ModifiedBy = UserId,
                            ModifiedDate = DateTime.Now,
                            TeamMatchMappings = checkAvailableTeam.TeamMatchMappings,
                            TeamMembers = checkAvailableTeam.TeamMembers
                        };

                        uow.TeamRepository.Update(InsertTeam);
                        uow.Commit();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                else
                {
                    var InsertTeam = new Team
                    {
                        TeamName = team.TeamName,
                        CreateDate = DateTime.Now,
                        CreatedBy = UserId,
                        IsRemove = false,
                        ModifiedBy = UserId,
                        ModifiedDate = DateTime.Now,
                        TeamMatchMappings = null,
                        TeamMembers = null
                    };

                    uow.TeamRepository.Insert(InsertTeam);
                    uow.Commit();
                    return true;
                }
            }
            catch(Exception er)
            {
                var message = er.Message;
                return false;
            }

        }

        public bool DeleteTeam(int TeamId, string UserId)
        {
            try
            {
                var checkAvalaibility = uow.TeamRepository.Get(x => x.Id == TeamId && !x.IsRemove).FirstOrDefault();

                if (checkAvalaibility != null)
                {
                    checkAvalaibility.IsRemove = false;
                    checkAvalaibility.ModifiedBy = UserId;
                    checkAvalaibility.ModifiedDate = DateTime.Now;
                    checkAvalaibility.TeamMembers = null;

                    var TeamMembers = checkAvalaibility.TeamMembers;

                    if(TeamMembers.Count!=0)
                    {
                        foreach(var TeamMember in TeamMembers)
                        {
                            TeamMember.Team = null;
                            TeamMember.TeamId = 0;

                            uow.TeamMemberRepository.Update(TeamMember);
                            uow.Commit();
                        }
                    }

                    uow.TeamRepository.Update(checkAvalaibility);
                    uow.Commit();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception er)
            {
                var Message = er.Message;
                return false;
            }
        }

        public bool AddTeamMemberIntoTeam(int TeamId, int TeamMemberId, string UserId)
        {
            var TeamMember = uow.TeamMemberRepository.GetByID(TeamMemberId);
            var Team = uow.TeamRepository.GetByID(TeamId);
            if(TeamMember!=null && TeamMember.Team==null && TeamMember.IsRemove==false && Team!=null && Team.IsRemove==false)
            {
                if(Team.TeamMembers.Count<2)
                {
                    Team.ModifiedBy = UserId;
                    Team.ModifiedDate = DateTime.Now;

                    Team.TeamMembers.Add(TeamMember);
                    TeamMember.Team = Team;
                    TeamMember.ModifiedBy = UserId;
                    TeamMember.ModifiedDate = DateTime.Now;

                    uow.TeamRepository.Update(Team);
                    uow.TeamMemberRepository.Update(TeamMember);

                    uow.Commit();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public List<TeamMemberDTO> GetTeamMemberByTeam(int TeamId)
        {
            return uow.TeamRepository.Get(x => x.Id == TeamId).FirstOrDefault().TeamMembers.Select(y => new TeamMemberDTO {
                    Id = y.Id,
                    TeamId = y.TeamId,
                    TeamMemberName = y.TeamMemberName,
                    Team = new TeamDTO { Id = y.Team.Id, TeamName = y.Team.TeamName }
            }).ToList();
        }

        public bool RemoveTeamMemberFromTeam(int TeamId, int TeamMemberId, string UserId)
        {
            var TeamMember = uow.TeamMemberRepository.GetByID(TeamMemberId);

            if(TeamMember!=null)
            {
                if(TeamMember.Team.Id == TeamId)
                {
                    if(TeamMember.Team.IsRemove==false)
                    {
                        TeamMember.Team = null;
                        TeamMember.TeamId = 0;
                        TeamMember.ModifiedBy = UserId;
                        TeamMember.ModifiedDate = DateTime.Now;

                        uow.TeamMemberRepository.Update(TeamMember);
                        uow.Commit();
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }

    public interface ITeamMasterService
    {
        TeamDTO GetTeamById(int TeamId);
        List<TeamDTO> GetAllTeam();
        bool DeleteTeam(int TeamId, string UserId);

        bool CreateOrUpdateTeam(TeamDTO team, string UserId);

        bool AddTeamMemberIntoTeam(int TeamId, int TeamMemberId, string UserId);

        bool RemoveTeamMemberFromTeam(int TeamId, int TeamMemberId, string UserId);

        List<TeamMemberDTO> GetTeamMemberByTeam(int TeamId);

    }
}
