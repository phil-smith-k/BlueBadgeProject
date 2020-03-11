using Basketball.Data;
using Basketball.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Services
{
    public class GameService
    {
        public bool CreateGame(CreateNewGame model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new Game()
                {
                    HomeTeam = ctx.Teams.Single(t => t.Name == model.HomeTeam),
                    AwayTeam = ctx.Teams.Single(t => t.Name == model.AwayTeam),
                    Date = model.Date,
                    // HomeTeamScore = model.HomeTeamScore,
                    // AwayTeamScore = model.AwayTeamScore,

                };
                    ctx.Games.Add(entity);
                    return ctx.SaveChanges() == 1;
                
            };

        }
        public GameDetails GetGameById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                // var query = ctx.Games.Include(g => g.)
                var query = ctx.Games.ToList();
                var entity = ctx.Games
                   .Single(g => g.GameId == id);
                var playerStats = entity.PlayerStats.ToList();

                return new GameDetails()
                {
                    GameId = entity.GameId,
                    HomeTeamName = entity.HomeTeam.Name,
                    AwayTeamName = entity.AwayTeam.Name,
                    Location = entity.Location,
                    Date = entity.Date.ToShortDateString(),
                    HomeTeamScore = entity.HomeTeamScore,
                    AwayTeamScore = entity.AwayTeamScore,
                    WinningTeamName = entity.Winner,
                    LosingTeamName = entity.Loser,
                    PlayerStats = playerStats
                };

            }
        }
        public IEnumerable<GameList> GetGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Games.ToList();

                var result = query.Select(g =>
                    new GameList()
                    {
                        GameId = g.GameId,
                        Date = g.Date.ToShortDateString(),
                        Location = g.Location,
                        HomeTeamName = g.HomeTeam.Name,
                        AwayTeamName = g.AwayTeam.Name,
                        HomeTeamScore = g.HomeTeamScore,
                        AwayTeamScore = g.AwayTeamScore,
                        Winner = g.Winner
                    });
                return result.ToArray();
            }
        }
        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Games.Single(g => g.GameId == model.GameId);

                entity.HomeTeamId = model.HomeTeamId;
                entity.AwayTeamId = model.AwayTeamId;
                entity.Date = model.Date;
                // entity.HomeTeamScore = model.HomeTeamScore;
                // entity.AwayTeamScore = model.AwayTeamScore;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteGame(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Games.Single(g => g.GameId == id);

                ctx.Games.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
