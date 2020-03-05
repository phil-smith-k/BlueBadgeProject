using Basketball.Models;
using Basketball.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Basketball.API.Controllers
{
    public class TeamController : ApiController
    {
        public IHttpActionResult Get()
        {
            TeamService teamService = CreateTeamService();
            var notes = teamService.GetTeams();
            return Ok(notes);
        }

        public IHttpActionResult Get(int id)
        {
            TeamService teamService = CreateTeamService();
            var note = teamService.GetTeamById(id);
            return Ok(note);
        }

        public IHttpActionResult Post(CreateNewTeam note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTeamService();

            if (!service.CreateNewTeam(note))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(TeamEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTeamService();

            if (!service.UpdateTeam(note))
                return InternalServerError();

            return Ok();
        }

        private TeamService CreateTeamService()
        {
            var noteService = new TeamService();
            return noteService;
        }


        public IHttpActionResult Delete(int id)
        {
            var service = CreateTeamService();

            if (!service.DeleteTeam(id))
                return InternalServerError();

            return Ok();
        }
    }
}
