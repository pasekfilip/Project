using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models.Tables;
namespace WebAPI.Models
{
    public class FriendRepository
    {
        private MyContext context = new MyContext();

        public List<Friends> FindAll()
        {
            return this.context.Friends.ToList();
        }

        public Friends FindById(int id)
        {
            return this.context.Friends.Find(id);
        }

        public void Create(Friends friend)
        {
            this.context.Friends.Add(friend);
            this.context.SaveChanges();
        }

        public void Update(Friends friend, int id)
        {
            //User current = this.FindById(id);
            //current.UserName = user.UserName;
            //current.Email = user.Email;
            //current.Password = user.Password;
            //current.Picture = user.Picture;


            //this.context.SaveChanges();

            Friends entity = this.FindById(id);
            if (entity == null)
                return;
            context.Entry(entity).CurrentValues.SetValues(friend);
            context.SaveChanges();
            //this.context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            //this.context.SaveChanges();
        }

        public void Delete(Friends friend)
        {
            this.context.Friends.Remove(friend);
            this.context.SaveChanges();
        }
    }
}
