using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTServer.Models;

namespace RESTServer.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "User1", "User2" };
        }

        // GET: api/User/5
        public User Get(string id)
        {
            UserPersistence up = new UserPersistence();
            User user = up.getUser(id);

            /*user.User_ID = id;
            user.UserName = "Jack Cottrell";
            user.UserEmail = "jack.cottrell@my.uu.edu";
            user.Description = "dope guy wrote this api";
            */
            return user;
        }

        // POST: api/User
        public HttpResponseMessage Post([FromBody]User value)
        {
            UserPersistence up = new UserPersistence();
            string id;
            id = up.saveUser(value);
            value.User_ID = id;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("user/{0}", id));
            return response;
        }

        // PUT: api/User/5
        public void Put(string id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(string id)
        {
        }
    }
}
