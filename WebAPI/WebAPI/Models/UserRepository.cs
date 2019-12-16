using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class UserRepository
    {
        private MyContext context = new MyContext();

        public List<Users> FindAll()
        {
            return this.context.Users.ToList();
        }

        public Users FindById(int id)
        {
            //return this.context.Users.Where(x => x.Id == id).FirstOrDefault();
            return this.context.Users.Find(id);
        }

        public void Create(Users user)
        {
            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public void Update(Users user,int id)
        {
            //Users current = this.FindById(id);
            //current.UserName = user.UserName;
            //current.Email = user.Email;
            //current.Password = user.Password;
            //current.Picture = user.Picture;


            //this.context.SaveChanges();

            Users entity = this.FindById(id);
            if (entity == null)
                return;
            context.Entry(entity).CurrentValues.SetValues(user);
            context.SaveChanges();
            //this.context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            //this.context.SaveChanges();
        }

        public void Delete(Users user)
        {
            this.context.Users.Remove(user);
            this.context.SaveChanges();
        }
    }
}