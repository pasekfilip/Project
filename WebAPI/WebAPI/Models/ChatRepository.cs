using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models.Tables;

namespace WebAPI.Models.Tables
{
    public class ChatRepository
    {
        private MyContext context = new MyContext();
        
        public List<Chat> FindAll()
        {
            return this.context.Chats.ToList();
        }

        public Chat FindById(int id)
        {
            //return this.context.Chat.Where(x => x.Id == id).FirstOrDefault();
            return this.context.Chats.Find(id);
        }

        public void Create(Chat chats)
        {
            this.context.Chats.Add(chats);
            this.context.SaveChanges();
        }

        public void Update(Chat chats, int id)
        {
            Chat entity = this.FindById(id);
            if (entity == null)
                return;
            context.Entry(entity).CurrentValues.SetValues(chats);
            context.SaveChanges();
        }

        public void Delete(int idChat)
        {
          
            Chat chat = this.FindById(idChat);
            this.context.Chats.Remove(chat);
            this.context.SaveChanges();
        }
    }

}
