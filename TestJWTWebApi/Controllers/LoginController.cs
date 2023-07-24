using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using TestJWTWebApi.Handlers;
using TestJWTWebApi.Models;

namespace TestJWTWebApi.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Authenticate([FromBody] LoginRequest loginrequest)
        {            
            IHttpActionResult response;
            bool isUsernamePasswordValid = CheckUser(loginrequest);            
            if (isUsernamePasswordValid)
            {
                string token = TokenManager.CreateToken(loginrequest.Username.ToLower());                
                return Ok<string>(token);
            }
            else
            {            
                response = ResponseMessage(new HttpResponseMessage(HttpStatusCode.Unauthorized));
                return response;
            }
        }

        private bool CheckUser(LoginRequest loginrequest)
        {
            if (loginrequest == null)
            {
                return false;
            }
            return loginrequest.Password == "admin" ? true : false;
        }        
    }
}
