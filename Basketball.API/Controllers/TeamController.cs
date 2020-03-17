using Basketball.Data;
using Basketball.Models;
using Basketball.Services;
using Microsoft.AspNet.Identity;
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
            var teams = teamService.GetTeams();
            return Ok(teams);
        }

        public IHttpActionResult Get(int id)
        {
            TeamService teamService = CreateTeamService();
            var team = teamService.GetTeamById(id);
            return Ok(team);
        }

        public IHttpActionResult Post(CreateNewTeam team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTeamService();

            if (!service.CreateNewTeam(team))
                return InternalServerError();

            return Ok();
        }
        [Authorize]
        [HttpPost]
        [Route("api/team/{id}")]
        public IHttpActionResult PostFavorite(int id)
        {
            var user = Guid.Parse(this.User.Identity.GetUserId());

            var service = CreateTeamService();

            if (!service.AddToFavoriteList(id, user))
                return InternalServerError();

            return Ok();
        }
        [Authorize]
        [HttpDelete]
        [Route("api/team/{id}")]
        public IHttpActionResult RemoveFavorite(int id)
        {
            var user = Guid.Parse(this.User.Identity.GetUserId());

            var service = CreateTeamService();

            if (!service.RemoveFromFavoriteList(id, user))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(TeamEdit team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTeamService();

            if (!service.UpdateTeam(team))
                return InternalServerError();

            return Ok();
        }

        private TeamService CreateTeamService()
        {
            var teamService = new TeamService();
            return teamService;
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
