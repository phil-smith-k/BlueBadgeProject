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
                return
                    new ConferenceDetails
                    {
                        ConferenceId = entity.ConferenceId,
                        ConferenceName = entity.Name,
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
