using Basketball.Data;
using Basketball.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Services
{
    public class TeamService
    {
        public TeamDetails GetTeamById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Include("Roster")
                        .Single(e => e.TeamId == id);
                var roster = entity.Roster.ToList();
                var homeGameLog = entity.HomeGameLog.ToList();
                var awayGameLog = entity.AwayGameLog.ToList();
                var allGames = entity.AllGames.OrderByDescending(g => g.Date).ToList();
                // var playerStats = entity.PlayerStats.ToList();
                foreach(Player player in entity.Roster)
                {
                    player.PlayerStats.ToList();
                }
                return
                    new TeamDetails
                    {
                        Location = entity.Location,
                        Name = entity.Name,
                        ConferenceName = entity.Conference.Name,
                        Record = entity.Record,
                        Players = roster.Select(c => new PlayerList { FullName = c.FullName, PlayerId = c.PlayerId, TeamName = c.Team.Name, AveragePoints = c.AveragePoints}).ToList(), 
                        AllGames = allGames.Select(g => new GameList { GameId = g.GameId, Date = g.Date.ToShortDateString(), Location = g.Location, HomeTeamName = g.HomeTeam.Name, AwayTeamName = g.AwayTeam.Name, HomeTeamScore = g.HomeTeamScore, AwayTeamScore = g.AwayTeamScore, Winner = g.Winner }).ToList()
                    };
            }
        }

        public bool CreateNewTeam(CreateNewTeam model)
        {
            var entity =
                new Team()
                {
                    Location = model.Location,
                    Name = model.Name,
                    ConferenceId = model.ConferenceId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Teams.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TeamList> GetTeams()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Teams.ToList()
                        .OrderByDescending(g => g.Wins)
                        .Select(T =>
                                new TeamList
                                {
                                    Location = T.Location,
                                    Name = T.Name,
                                    Conference = T.Conference.Name,
                                    Record = T.Record
                                }
                         );

                return query.ToArray();
            }
        }
        public bool UpdateTeam(TeamEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamId == model.TeamId);
                entity.Location = model.Location;
                entity.Name = model.Name;
                entity.ConferenceId = model.ConferenceId;
                entity.TeamId = model.TeamId;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteTeam(int TeamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamId == TeamId);

                ctx.Teams.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
