using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace TestJWTWebApi.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        private string GetUserName()
        {
            string userName = "Undefined user!";
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userNameClaim = identity.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault();
                userName = userNameClaim.Value;
            }
            return userName;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "Hello", GetUserName() };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
