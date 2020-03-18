using Basketball.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Basketball.API.Controllers
{
    public class FavoritesController : Controller
    {
        // GET: TeamList
        //[System.Web.Mvc.Route("/Favorites")]
        public ActionResult MyFavorites()
        {
            IEnumerable<TeamList> teams = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44337/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Team");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<TeamList>>();
                    readTask.Wait();

                    teams = readTask.Result;
                }
                else
                {
                    teams = Enumerable.Empty<TeamList>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(teams);
        }
        public ActionResult TeamDetails(int id)
        {
            TeamDetails team = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44337/api/");
                //HTTP GET BY ID
                var responseTask = client.GetAsync($"Team/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<TeamDetails>();
                    readTask.Wait();

                    team = readTask.Result;
                }
                else
                {
                    team = new TeamDetails();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(team);
        }
        public ActionResult GameDetails(int id)
        {
            GameDetails game = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44337/api/");
                //HTTP GET BY ID
                var responseTask = client.GetAsync($"Game/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<GameDetails>();
                    readTask.Wait();

                    game = readTask.Result;
                }
                else
                {
                    game = new GameDetails();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(game);
        }
        //This will work for both conferences
        public ActionResult EastConference(int id)
        {
            ConferenceDetails team = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44337/api/");
                //HTTP GET BY ID
                var responseTask = client.GetAsync($"Conference/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ConferenceDetails>();
                    readTask.Wait();

                    team = readTask.Result;
                }
                else
                {
                    team = new ConferenceDetails();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(team);
        }
    }
}
