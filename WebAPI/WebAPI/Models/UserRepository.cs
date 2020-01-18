using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models.Tables;
namespace WebAPI.Models
{
    public class UserRepository
    {
        private MyContext context = new MyContext();

        public List<User> FindAll()
        {
            return this.context.User.ToList();
        }
        public List<User> FindUsersByIDs(int[] IDs)
        {
            return this.context.User.Where(user => IDs.Contains(user.ID)).ToList();
        }
        public User FindByUserName(string uName)
        {
            return this.context.User.Where(x => x.UserName == uName).FirstOrDefault();
        }
        public User FindById(int id)
        {
            //return this.context.User.Where(x => x.Id == id).FirstOrDefault();
            return this.context.User.Find(id);
        }

        public void Create(User user)
        {
            this.context.User.Add(user);
            this.context.SaveChanges();
        }

        public void Update(User user,int id)
        {
            //Chat current = this.FindById(id);
            //current.ChatName = Chat.ChatName;
            //current.Email = Chat.Email;
            //current.Password = Chat.Password;
            //current.Picture = Chat.Picture;


            //this.context.SaveChanges();

            User entity = this.FindById(id);
            if (entity == null)
                return;
            context.Entry(entity).CurrentValues.SetValues(user);
            context.SaveChanges();
            //this.context.Entry(Chat).State = System.Data.Entity.EntityState.Modified;
            //this.context.SaveChanges();
        }

        public void Delete(User user)
        {
            this.context.User.Remove(user);
            this.context.SaveChanges();
        }
    }
}