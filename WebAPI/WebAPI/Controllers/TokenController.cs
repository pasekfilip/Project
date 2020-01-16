using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models;
using WebAPI.Models.Tables;
namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TokenController : ApiController
    {
        private TokenRepository repository = new TokenRepository();


        [Route("api/Token")]
        [HttpPost]
        public string Login([FromBody]Login login)
        {
            return this.repository.GetToken(login);
        }
    
        [Route("api/Token/Validate")]
        [HttpPost]
        public bool ValidateToken([FromBody]string token)
        {
            return this.repository.ValidateToken(token);
        }

    }
}
