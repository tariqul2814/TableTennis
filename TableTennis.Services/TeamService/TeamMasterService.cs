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
    public class TeamMasterService : ITeamService
    {
        private readonly IUoW uow;
        public TeamMasterService(IUoW _uow)
        {
            uow = _uow;
        }

        public Team GetTeamById(int TeamId)
        {
            return uow.TeamRepository.Get(x => x.IsRemove == false && x.Id == TeamId).Select(x=> new Team {
                Id = x.Id,
                Point = x.Point,
                TeamName = x.TeamName,
                TeamMatches = x.TeamMatches,
                TeamMembers = x.TeamMembers
            }).FirstOrDefault();
        }

        public List<Team> GetAllTeam()
        {
            return uow.TeamRepository.GetAll().Select(x => new Team
            {
                Id = x.Id,
                Point = x.Point,
                TeamName = x.TeamName,
                TeamMatches = x.TeamMatches,
                TeamMembers = x.TeamMembers
            }).ToList();
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
                            Point = checkAvailableTeam.Point,
                            CreateDate = checkAvailableTeam.CreateDate,
                            CreatedBy = checkAvailableTeam.CreatedBy,
                            IsRemove = false,
                            ModifiedBy = UserId,
                            ModifiedDate = DateTime.Now,
                            TeamMatches = checkAvailableTeam.TeamMatches,
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
                            Point = checkAvailableTeam.Point,
                            CreateDate = checkAvailableTeam.CreateDate,
                            CreatedBy = checkAvailableTeam.CreatedBy,
                            IsRemove = false,
                            ModifiedBy = UserId,
                            ModifiedDate = DateTime.Now,
                            TeamMatches = checkAvailableTeam.TeamMatches,
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
                        Point = team.Point,
                        CreateDate = DateTime.Now,
                        CreatedBy = UserId,
                        IsRemove = false,
                        ModifiedBy = UserId,
                        ModifiedDate = DateTime.Now,
                        TeamMatches = null,
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

    }

    public interface ITeamService
    {
        Team GetTeamById(int TeamId);
        List<Team> GetAllTeam();
        bool DeleteTeam(int TeamId, string UserId);

        bool CreateOrUpdateTeam(TeamDTO team, string UserId);
    }
}
