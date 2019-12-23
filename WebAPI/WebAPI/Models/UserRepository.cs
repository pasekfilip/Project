﻿using System;
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
            //User current = this.FindById(id);
            //current.UserName = user.UserName;
            //current.Email = user.Email;
            //current.Password = user.Password;
            //current.Picture = user.Picture;


            //this.context.SaveChanges();

            User entity = this.FindById(id);
            if (entity == null)
                return;
            context.Entry(entity).CurrentValues.SetValues(user);
            context.SaveChanges();
            //this.context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            //this.context.SaveChanges();
        }

        public void Delete(User user)
        {
            this.context.User.Remove(user);
            this.context.SaveChanges();
        }
    }
}