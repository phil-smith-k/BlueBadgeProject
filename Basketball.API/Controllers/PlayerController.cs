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
    public class PlayerController : ApiController
    {
        public IHttpActionResult Get()
        {
            PlayerService playerService = CreatePlayerService();
            var players = playerService.GetPlayers();
            return Ok(players);
        }
        public IHttpActionResult Post(CreateNewPlayer player)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePlayerService();

            if (!service.CreatePlayer(player))
                return InternalServerError();

            return Ok();
        }
        private PlayerService CreatePlayerService()
        {
            var playerService = new PlayerService();
            return playerService;
        }
        public IHttpActionResult Get(int id)
        {
            PlayerService playerService = CreatePlayerService();
            var player = playerService.GetPlayerById(id);
            return Ok(player);
        }
        public IHttpActionResult Put(PlayerEdit player)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePlayerService();

            if (!service.UpdatePlayer(player))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePlayerService();

            if (!service.DeletePlayer(id))
                return InternalServerError();

            return Ok();
        }
    }
}
