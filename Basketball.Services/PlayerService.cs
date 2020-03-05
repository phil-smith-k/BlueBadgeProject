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
            var entity =
                new Player()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    TeamId = model.TeamId
                };
            using (var ctx = new ApplicationDbContext())
            {
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
                        .Players
                        .Select(
                            e =>
                                new PlayerList
                                {
                                    PlayerId = e.PlayerId,
                                    FullName = e.FullName,
                                    TeamName = e.Team.Name
                                }
                        );
                return query.ToArray();
            }
        }
        public PlayerDetails GetPlayerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerId == id);
                return
                    new PlayerDetails
                    {
                        PlayerId = entity.PlayerId,
                        FullName = entity.FullName,
                        TeamName = entity.Team.Name,
                    };
            }
        }
        /*public bool UpdateNote(NoteEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerId == model.NoteId);
                entity.Title = model.Title;
                entity.Content = model.Content;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePlayer(int playerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == noteId && e.OwnerId == _userId);

                ctx.Notes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }*/
    }
}

