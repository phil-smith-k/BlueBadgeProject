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
                        .Single(e => e.TeamId == id);
                return
                    new TeamDetails
                    {
                        Location = entity.Location,
                        Name = entity.Name,
                        ConferenceId = entity.ConferenceId
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

        public IEnumerable<TeamDetails> GetTeams()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Teams
                        .Select(T =>
                                new TeamDetails
                                {
                                    Location = T.Location,
                                    Name = T.Name,
                                    ConferenceId = T.ConferenceId
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
