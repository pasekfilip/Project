using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Models.Tables;

namespace WebAPI.Controllers
{
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
        public Message Get(int id)
        {
            return this.repository.FindById(id);
        }

        [Route("api/Messages")]
        [HttpPost]
        public void Post([FromBody]Message value)
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


        [Route("api/Message/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            Message message = this.repository.FindById(id);
            this.repository.Delete(message);
        }
    }
}
