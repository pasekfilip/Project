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
        private ChatRepository chatRep = new ChatRepository();
        public List<Chat_Member> FindAll()
        {
            return this.context.Chat_Members.ToList();
        }

        public Chat_Member FindById(int id)
        {
            return this.context.Chat_Members.Where(x => x.ID_User == id).FirstOrDefault();

        }
        public int ReturnChatID(int[] Ids)
        {
            int indexA = Ids[0];
            int indexB = Ids[1];

            List<Chat_Member> chat1 = this.context.Chat_Members.Where(x => x.ID_User == indexA).ToList();
            List<Chat_Member> chat2 = this.context.Chat_Members.Where(x => x.ID_User == indexB).ToList();
            int ChatID = default;
            
            if (chat1 != null && chat2 != null && this.CheckIfBothUsersHaveTheSameChat(chat1,chat2,ref ChatID))
            {
                return ChatID;
            }
            else
            {
                chatRep.Create(new Chat { ID_Admin = indexA });
                Chat foo = this.context.Chats.OrderByDescending(x => x.ID).FirstOrDefault();
                int idChat = foo.ID;
                for (int i = 0; i < Ids.Length; i++)
                {
                    this.Create(new Chat_Member {ID_Chat = idChat ,ID_User = Ids[i] });
                }
                return idChat;
            }
        }
        public bool CheckIfBothUsersHaveTheSameChat(List<Chat_Member> member1, List<Chat_Member> member2, ref int id)
        {
            bool result = false;
            for (int i = 0; i < member1.Count(); i++)
            {
                for (int y = 0; y < member2.Count(); y++)
                {
                    if(member1[i].ID_Chat == member2[y].ID_Chat)
                    {
                        id = member1[i].ID_Chat;
                        return true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            return result;
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

        public void Delete(int idChat)
        {
            this.context.Chat_Members.RemoveRange(this.context.Chat_Members.Where(x => x.ID_Chat == idChat));
            this.context.SaveChanges();
        }
    }
}