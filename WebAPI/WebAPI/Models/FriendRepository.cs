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
        private UserRepository rep = new UserRepository();
        public List<Friends> FindAll()
        {
            return this.context.Friends.ToList();
        }

        public List<Friends> FindByUserId(int id)
        {
            return this.context.Friends.Where(x => x.ID_User == id).ToList();
        }

        public Object CheckIfUserExistsAndIfTheUserIsNotAlreadyAddedAsFriend(SearchFriend friend)
        {
            int? ID_Friend = this.rep.FindByUserName(friend.FriendName)?.ID;
            if(ID_Friend != null)
            {
                if(IfTheUserIsNotAlreadyAddedAsFriend())
                {
                    return true;
                }
                else
                {
                    return new { data = "You have this User added already" };
                }
            }
            else
            {
                return new { data = "User dosen't exist" };
            }

            bool IfTheUserIsNotAlreadyAddedAsFriend()
            {
                List<Friends> list = this.FindByUserId(friend.ID_User);
                for (int i = 0; i < list.Count(); i++)
                {
                    if(list[i].ID_Friend == ID_Friend)
                    {
                        return false;
                    }
                    else { }

                }
                return true;
            }
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
        public void CreateFriendWithFriendSearch(SearchFriend searchFriend)
        {
            int ID_Friend = this.rep.FindByUserName(searchFriend.FriendName).ID;
            Friends friend = new Friends();
            friend.ID_User = searchFriend.ID_User;
            friend.ID_Friend = ID_Friend;
            this.Create(friend);
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
