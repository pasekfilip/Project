using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models.Tables;

namespace WebAPI.Models
{
    public class MessageRepository
    {
        private MyContext context = new MyContext();

        public List<Message> FindAll()
        {
            return this.context.Messages.ToList();
        }

        public Message FindById(int id)
        {
            //return this.context.Chat.Where(x => x.Id == id).FirstOrDefault();
            return this.context.Messages.Find(id);
        }
        public List<Message> FindByChatID(int chatId)
        {
            return this.context.Messages.Where(x => x.ID_Chat == chatId).ToList();
        }
        public void Create(Message message)
        {
            this.context.Messages.Add(message);
            this.context.SaveChanges();
        }

        public void Update(Message message, int id)
        {
            Message entity = this.FindById(id);
            if (entity == null)
                return;
            context.Entry(entity).CurrentValues.SetValues(message);
            context.SaveChanges();
        }

        public void Delete(int idChat)
        {
            this.context.Messages.RemoveRange(this.context.Messages.Where(x => x.ID_Chat == idChat));
            this.context.SaveChanges();
        }
    }
}