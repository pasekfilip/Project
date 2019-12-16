using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class PersonRepository
    {
        private MyContext context = new MyContext();

        public List<User> FindAll()
        {
            return this.context.Users.ToList();
        }

        public User FindById(int id)
        {
            //return this.context.Users.Where(x => x.Id == id).FirstOrDefault();
            return this.context.Users.Find(id);
        }

        public void Create(User user)
        {
            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public void Update(User user)
        {
            /*Person current = this.FindById(person.Id);

            current.Name = person.Name;
            current.Surname = person.Surname;
            current.Age = person.Age;

            this.context.SaveChanges();*/

            this.context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();
        }

        public void Delete(User user)
        {
            this.context.Users.Remove(user);
            this.context.SaveChanges();
        }
    }
}