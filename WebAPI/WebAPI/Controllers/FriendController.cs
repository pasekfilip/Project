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
    public class FriendController : ApiController
    {
        // GET: api/Friend

        private FriendRepository repository = new FriendRepository();

        // GET: api/Friends
        [Route("api/Friends")]
        [HttpGet]
        public IEnumerable<Friends> Get()
        {
            return this.repository.FindAll();
        }

        // GET: api/Friends/5
        [Route("api/Friends/{id}")]
        [HttpGet]
        public Friends Get(int id)
        {
            return this.repository.FindById(id);
        }
        [Route("api/Friends/UserID/{id}")]
        [HttpGet]
        public List<Friends> GetFrindsByUserID(int id)
        {
            return this.repository.FindByUserId(id);
        }
        [Route("api/Friends/SearchForFriend")]
        [HttpPost]
        public Object SearchForFriend(SearchFriend friend)
        {
            return this.repository.CheckIfUserExistsAndIfTheUserIsNotAlreadyAddedAsFriend(friend);
        }
        [Route("api/Friends/CreateFriend")]
        [HttpPost]
        public void CreateFriend(SearchFriend friend)
        {
            this.repository.CreateFriendWithFriendSearch(friend);
        }

        // POST: api/Friends
        [Route("api/Friends")]
        [HttpPost]
        public void Post([FromBody]Friends value)
        {
            this.repository.Create(value);
        }

        // DELETE: api/Friends/5
        [Route("api/Friends/Delete")]
        [HttpDelete]
        public void Delete(Friends friends)
        {
            this.repository.Delete(friends);
        }
    }
}
