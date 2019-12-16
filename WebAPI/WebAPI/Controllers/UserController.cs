using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private UserRepository repository = new UserRepository();

        // GET: api/Users
        [Route("api/Users")]
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return this.repository.FindAll();
        }

        // GET: api/Users/5
        [Route("api/Users/{id}")]
        [HttpGet]
        public Users Get(int id)
        {
            return this.repository.FindById(id);
        }

        // POST: api/Users
        [Route("api/Users")]
        [HttpPost]
        public void Post([FromBody]Users value)
        {
            this.repository.Create(value);
        }

        // PUT: api/Users/5
        [Route("api/Users/{id}")]
        [HttpPost]
        public void Put(int id, [FromBody]Users value)
        {
            value.ID = id;
            this.repository.Update(value,id);
        }

        // DELETE: api/Users/5
        [Route("api/Users/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            Users user = this.repository.FindById(id);
            this.repository.Delete(user);
        }
    }
}
