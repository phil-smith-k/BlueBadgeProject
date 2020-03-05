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
    public class ConferenceController : ApiController
    {
        public IHttpActionResult Get()
        {
            ConferenceService conferenceService = CreateConferenceService();
            var conference = conferenceService.GetConferences();
            return Ok(conference);
        }
        public IHttpActionResult Post(CreateNewConference conference)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateConferenceService();

            if (!service.CreateConference(conference))
                return InternalServerError();

            return Ok();
        }
        private ConferenceService CreateConferenceService()
        {
            var conferenceService = new ConferenceService();
            return conferenceService;
        }
        public IHttpActionResult Get(int id)
        {
            ConferenceService conferenceService = CreateConferenceService();
            var conference = conferenceService.GetConferenceById(id);
            return Ok(conference);
        }
        /*public IHttpActionResult Put(ConferenceEdit conference)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateConferenceService();

            if (!service.UpdateConference(conference))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateConferenceService();

            if (!service.DeleteConference(id))
                return InternalServerError();

            return Ok();
        }*/
    }
}
