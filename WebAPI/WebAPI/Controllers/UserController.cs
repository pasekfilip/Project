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
        private PersonRepository repository = new PersonRepository();

        // GET: api/Users
        public IEnumerable<User> Get()
        {
            return this.repository.FindAll();
        }

        // GET: api/Users/5
        public User Get(int id)
        {
            return this.repository.FindById(id);
        }

        // POST: api/Users
        public void Post([FromBody]User value)
        {
            this.repository.Create(value);
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]User value)
        {
            value.ID = id;
            this.repository.Update(value);
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
            User user = this.repository.FindById(id);
            this.repository.Delete(user);
        }
    }
}
