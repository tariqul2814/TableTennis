using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TableTennis.DataAccess.UnitOfWork;
using TableTennis.Services.DTO.TeamMatchService;
using TableTennis.Services.DTO.TeamService;

namespace TableTennis.Services.TeamMatchService
{
    public class TeamMatchMasterService : ITeamMatchMasterService
    {
        private readonly IUoW _uow;
        public TeamMatchMasterService(IUoW uoW)
        {
            _uow = uoW;
        }

        public List<TeamMatchDTO> GetAllTeamMatch()
        {
            return _uow.TeamMatchRepository.Get(x=> x.IsRemove!=false).OrderBy(x => x.Schedule.Id).Select(
                    x=> new TeamMatchDTO
                    {
                        Id = x.Id,
                        Schedule = new DTO.ScheduleService.ScheduleDTO
                        {
                            Id = x.ScheduleId,
                            MatchDay = x.Schedule.MatchDay
                        },
                        ScheduleId = x.ScheduleId,
                        TeamMatchMappings = x.TeamMatchMappings.Select(
                            y=> new TeamMatchMappingsDTO { 
                                Id = y.Id,
                                Point = y.Point,
                                Team = new DTO.TeamService.TeamDTO
                                {
                                    Id = y.Team.Id,
                                    TeamName = y.Team.TeamName
                                },
                                TeamId = y.TeamId
                            }
                         ).ToList()
                    }).ToList();
        }

        public List<TeamMatchDTO> GetTeamMatchesByTeamId(int TeamId)
        {
            return _uow.TeamMatchMapping.Get(x => x.TeamId == TeamId).ToList().Select(y => new TeamMatchDTO
            {
                Schedule = new DTO.ScheduleService.ScheduleDTO
                {
                    Id = y.TeamMatch.ScheduleId,
                    MatchDay = y.TeamMatch.Schedule.MatchDay
                },
                ScheduleId = y.TeamMatch.ScheduleId
            }).ToList();
        }

        public bool UpdateTeamMatchScore(int TeamMatchId, int TeamId, int Score, string UserId)
        {
            var TeamMatchMappings = _uow.TeamMatchMapping.Get(x => x.TeamMatchId == TeamMatchId && x.TeamId == TeamId).FirstOrDefault();

            if(TeamMatchMappings!=null)
            {
                TeamMatchMappings.Point = Score;
                TeamMatchMappings.ModifiedBy = UserId;
                TeamMatchMappings.ModifiedDate = DateTime.Now;

                _uow.TeamMatchMapping.Update(TeamMatchMappings);
                _uow.Commit();
                return true;
            }
            else
            {
                return false;
            }    

        }
    }

    public interface ITeamMatchMasterService
    {
        List<TeamMatchDTO> GetAllTeamMatch();
        List<TeamMatchDTO> GetTeamMatchesByTeamId(int TeamId);
        public bool UpdateTeamMatchScore(int TeamMatchId, int TeamId, int Score, string UserId);
    }
}
