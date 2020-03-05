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
    public class GameController : ApiController
    {
        private GameService CreateGameService()
        {
            return new GameService();
        }

        public IHttpActionResult Post(CreateNewGame model)
        {
            var service = CreateGameService();

            if (model == null)
                return BadRequest();
            else
            {
                if(!service.CreateGame(model))
                    return InternalServerError();
                else
                {
                    return Ok();
                }
            }
        }

        public IHttpActionResult Get()
        {
            var service = CreateGameService();
            var games = service.GetGames();

            return Ok(games);
        }

        public IHttpActionResult Get(int id)
        {
            var service = CreateGameService();
            var game = service.GetGameById(id);

            if (game == null)
                return NotFound();
            else
                return Ok(game);
        }
        // Put
        public IHttpActionResult Put(GameEdit model)
        {
            var service = CreateGameService();
            if (model == null)
                return BadRequest();
             else
            {
                if (!service.UpdateGame(model))
                    return InternalServerError();
                else
                    return Ok();
            }
        }
        // Delete
        public IHttpActionResult Delete(int id)
        {
            var service = CreateGameService();

            if (!service.DeleteGame(id))
                return InternalServerError();
            else
                return Ok();
        }
    }
}
