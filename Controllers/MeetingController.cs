using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTServer.Models;

namespace RESTServer.Controllers
{
    public class MeetingController : ApiController
    {
        // GET: api/Meeting
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Meeting/5
        public Meeting Get(int id)
        {
            MeetingPersistence mp = new MeetingPersistence();
            Meeting meeting = mp.getMeeting(id);
            return meeting;
        }

        // POST: api/Meeting
        public HttpResponseMessage Post([FromBody]Meeting value)
        {
            MeetingPersistence mp = new MeetingPersistence();
            int id;
            id = mp.saveMeeting(value);
            value.Meeting_ID = id;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("meeting/{0}", id));
            return response;
        }

        // PUT: api/Meeting/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Meeting/5
        public void Delete(int id)
        {
        }
    }
}
