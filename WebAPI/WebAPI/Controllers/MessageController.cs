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
    public class MessageController : ApiController
    {
        private MessageRepository repository = new MessageRepository();

        [Route("api/Messages")]
        [HttpGet]
        public List<Message> Get()
        {
            return this.repository.FindAll();
        }


        [Route("api/Message/{id}")]
        [HttpGet]
        public List<Message> Get(int id)
        {
            return this.repository.FindByChatID(id);
        }

        [Route("api/Message")]
        [HttpPost]
        public void Post(Message value)
        {
            this.repository.Create(value);
        }


        [Route("api/Message/{id}")]
        [HttpPost]
        public void Put(int id, [FromBody]Message value)
        {
            value.ID = id;
            this.repository.Update(value, id);
        }
    }
}
