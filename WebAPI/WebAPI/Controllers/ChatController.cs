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
    public class ChatController : ApiController
    {
        private ChatRepository repository = new ChatRepository();

       
        [Route("api/Chats")]
        [HttpGet]
        public List<Chat> Get()
        {
            return this.repository.FindAll();
        }

      
        [Route("api/Chats/{id}")]
        [HttpGet]
        public Chat Get(int id)
        {
            return this.repository.FindById(id);
        }

        [Route("api/Chats")]
        [HttpPost]
        public void Post([FromBody]Chat value)
        {
            this.repository.Create(value);
        }

        
        [Route("api/Chats/{id}")]
        [HttpPost]
        public void Put(int id, [FromBody]Chat value)
        {
            value.ID = id;
            this.repository.Update(value, id);
        }

       
        [Route("api/Chats/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            Chat chat = this.repository.FindById(id);
            this.repository.Delete(chat);
        }
    }
}
