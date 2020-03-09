using Basketball.Data;
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
    public class PlayerStatsController : ApiController
    {
        public IHttpActionResult Get()
        {
            PlayerStatsService playerStats = CreatePlayerStatsService();
            var players = playerStats.GetPlayersStats();
            return Ok(players);
        }
        public IHttpActionResult Post(CreateNewPlayerStats createNewPlayerStats)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePlayerStatsService();

            if (!service.CreatePlayerStats(createNewPlayerStats))
                return InternalServerError();

            return Ok();
        }
        private PlayerStatsService CreatePlayerStatsService()
        {
            var playerService = new PlayerStatService();
            return playerService;
        }
        public IHttpActionResult Get(int id)
        {
            PlayerStatsService playerService = CreatePlayerStatsService();
            var player = playerService.GetPlayerById(id);
            return Ok(player);
        }
        public IHttpActionResult Put(PlayerEdit player)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePlayerStatsService();

            if (!service.UpdatePlayer(player))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePlayerStatsService();

            if (!service.DeletePlayer(id))
                return InternalServerError();

            return Ok();
        }
}
