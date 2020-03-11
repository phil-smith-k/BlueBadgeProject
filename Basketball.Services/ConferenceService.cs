using Basketball.Data;
using Basketball.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Services
{
    public class ConferenceService
    {
        public bool CreateConference(CreateNewConference model)
        {
            var entity =
                new Conference()
                {
                    Name = model.Name
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Conferences.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ConferenceList> GetConferences()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Conferences
                        .Select(
                            e =>
                                new ConferenceList
                                {
                                    ConferenceId = e.ConferenceId,
                                    ConferenceName = e.Name,
                                }
                        );
                return query.ToArray();
            }
        }
        public ConferenceDetails GetConferenceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Conferences
                        .Single(e => e.ConferenceId == id);
                
                var allTeams = entity.AllTeams.ToList();

                return
                    new ConferenceDetails
                    {
                        ConferenceId = entity.ConferenceId,
                        ConferenceName = entity.Name,
                        Teams = allTeams.OrderByDescending(t => t.Wins).Select(t => new TeamListConference { TeamId = t.TeamId, Name = t.Name, Location = t.Location, Record = t.Record}).ToList()
                    };
            }
        }
        public bool UpdateConference(ConferenceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Conferences
                        .Single(e => e.ConferenceId == model.ConferenceId);
                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteConference(int conferenceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Conferences
                        .Single(e => e.ConferenceId == conferenceId);

                ctx.Conferences.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
