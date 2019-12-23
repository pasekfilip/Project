using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models.Tables;

namespace WebAPI.Models
{
    public class Chat_MemberRepository
    {
        private MyContext context = new MyContext();

        public List<Chat_Member> FindAll()
        {
            return this.context.Chat_Members.ToList();
        }

        public Chat_Member FindById(int id)
        {
            //return this.context.Chat.Where(x => x.Id == id).FirstOrDefault();
            return this.context.Chat_Members.Find(id);
        }

        public void Create(Chat_Member chat_member)
        {
            this.context.Chat_Members.Add(chat_member);
            this.context.SaveChanges();
        }

        public void Update(Chat_Member chat_member, int id)
        {
            Chat_Member entity = this.FindById(id);
            if (entity == null)
                return;
            context.Entry(entity).CurrentValues.SetValues(chat_member);
            context.SaveChanges();
        }

        public void Delete(Chat_Member chat_member)
        {
            this.context.Chat_Members.Remove(chat_member);
            this.context.SaveChanges();
        }
    }
}