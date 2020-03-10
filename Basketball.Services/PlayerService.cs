using Basketball.Data;
using Basketball.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Services
{
    public class PlayerService
    {
        public bool CreatePlayer(CreateNewPlayer model)
        {
            using (var ctx = new ApplicationDbContext())
            {
            var entity =
                new Player()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Team = ctx.Teams.Single(t => t.Name == model.Team)
                };
                ctx.Players.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PlayerList> GetPlayers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Players.Include("PlayerStats").ToList();


                        var result = query.Select(
                            e =>
                                new PlayerList
                                {
                                    PlayerId = e.PlayerId,
                                    FullName = e.FullName,
                                    TeamName = e.Team.Name,
                                    AveragePoints = e.AveragePoints
                                }
                        );
                return result.ToArray();
            }
        }
        public PlayerDetails GetPlayerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Include("PlayerStats")
                        .Single(e => e.PlayerId == id);
                return
                    new PlayerDetails
                    {
                        PlayerId = entity.PlayerId,
                        FullName = entity.FullName,
                        TeamName = entity.Team.Name,
                        GamesPlayed = entity.GamesPlayed,
                        AveragePoints = entity.AveragePoints,
                        AverageRebounds = entity.AverageRebounds,
                        AverageAssists = entity.AverageAssists
                    };
            }
        }
        public bool UpdatePlayer(PlayerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerId == model.PlayerId);
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Team.Name = model.TeamName;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePlayer(int playerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerId == playerId);

                ctx.Players.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

