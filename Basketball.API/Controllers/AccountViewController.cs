using Basketball.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Basketball.API.Controllers
{
    public class AccountViewController : Controller
    {
        // GET: AccountView
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(RegisterBindingModel model)
        {
            using (var client = new HttpClient())
            {
                var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Email", model.Email),
                    new KeyValuePair<string, string>("username", model.Password),
                    new KeyValuePair<string, string>("password", model.ConfirmPassword)
                };

                var content = new FormUrlEncodedContent(pairs);
                client.BaseAddress = new Uri("https://localhost:44337/api");
                var response = client.PostAsync("Account/Register", content).Result;
                var token = response.Content.ReadAsStringAsync().Result;
                Response.Cookies.Add(CreateCookies(token));

                return View();
            }
        }
        public ActionResult Login(ClientLoginBindingModel model)
        {
            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", model.UserName),
                new KeyValuePair<string, string>("password", model.Password)
            };
            var content = new FormUrlEncodedContent(pairs);
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44337/");
                var response = client.PostAsync("Token", content).Result;
                var token = response.Content.ReadAsStringAsync().Result;
                Response.Cookies.Add(CreateCookies(token));

                return View();
            }
        }
        private HttpCookie CreateCookies(string token)
        {
            HttpCookie loginCookies = new HttpCookie("UserToken");
            loginCookies.Value = token;
            return loginCookies;
        }
    }
}