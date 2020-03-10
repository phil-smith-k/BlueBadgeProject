using Basketball.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Basketball.API.Controllers
{
    public class TeamListController : Controller
    {
        // GET: TeamList
        public ActionResult Index()
        {
            IEnumerable<TeamList> students = null;

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

                    students = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    students = Enumerable.Empty<TeamList>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(students);
        }
    }
}