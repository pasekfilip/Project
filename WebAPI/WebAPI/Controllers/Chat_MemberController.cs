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
    public class Chat_MemberController : ApiController
    {
        private Chat_MemberRepository repository = new Chat_MemberRepository();

        [Route("api/Chat_Members")]
        [HttpGet]
        public List<Chat_Member> Get()
        {
            return this.repository.FindAll();
        }


        [Route("api/Chat_Member/{id}")]
        [HttpGet]
        public Chat_Member Get(int id)
        {
            return this.repository.FindById(id);
        }
        [Route("api/Chat_Members/ChatID")]
        [HttpPost]
        public int GetChatID([FromBody]int[] Ids)
        {
            return this.repository.ReturnChatID(Ids);
        }

        [Route("api/Chat_Members")]
        [HttpPost]
        public void Post([FromBody]Chat_Member value)
        {
            this.repository.Create(value);
        }


        //[Route("api/Chat_Members/{id}")]
        //[HttpPost]
        //public void Put(int id, [FromBody]Chat_Member value)
        //{
        //    value.ID = id;
        //    this.repository.Update(value, id);
        //}


        [Route("api/Chat_Member/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            Chat_Member chat_member = this.repository.FindById(id);
            this.repository.Delete(chat_member);
        }
    }
}
