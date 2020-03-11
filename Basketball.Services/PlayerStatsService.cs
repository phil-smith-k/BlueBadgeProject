using Basketball.Data;
using Basketball.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Services
{
    public class PlayerStatsService
    {
        public bool CreatePlayerStats(CreateNewPlayerStats model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new PlayerStats
                {
                    GameId = model.GameId,
                    Player = ctx.Players.Single(d => d.LastName == model.Player),
                    Points = model.Points,
                    Rebounds = model.Rebounds,
                    Assists = model.Assists
                };

                ctx.PlayerStats.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PlayerStatsList> GetPlayerStats()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.PlayerStats.ToList().OrderByDescending(w => w.PlayerStatsId).Select(ps => new PlayerStatsList
                {
                    PlayerStatsId = ps.PlayerStatsId,
                    GameId = ps.GameId,
                    Date = ps.Game.Date.ToShortDateString(),
                    FullName = ps.Player.FullName,
                    Points = ps.Points,
                    Rebounds = ps.Rebounds,
                    Assists = ps.Assists
                });

                return query.ToArray();

            }
        }
        public PlayerStatsDetails GetPlayerStatsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PlayerStats.Find(id);

                return new PlayerStatsDetails
                {
                    PlayerStatsId = entity.PlayerStatsId,
                    PlayerId = entity.PlayerId,
                    GameId = entity.GameId,
                    FullName = entity.Player.FullName,
                    Date = entity.Game.Date,
                    Points = entity.Points,
                    Rebounds = entity.Rebounds,
                    Assists = entity.Assists
                };
            }
        }
        public bool UpdatePlayerStats(PlayerStatsEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PlayerStats.Find(model.PlayerStatsId);

                entity.GameId = model.GameId;
                entity.Player.LastName = model.Player;
                entity.Points = model.Points;
                entity.Rebounds = model.Rebounds;
                entity.Assists = model.Assists;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePlayerStats(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PlayerStats.Find(id);

                ctx.PlayerStats.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
