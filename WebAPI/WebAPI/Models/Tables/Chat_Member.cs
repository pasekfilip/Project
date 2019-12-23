using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Tables
{

    [Table("Chat_Members")]
    public class Chat_Member
    {
        [Key,ForeignKey("Chats"),Column(Order = 0)]
        public int ID_Chat { get; set; }
        [Key,ForeignKey("Users"), Column(Order = 1)]
        public int ID_User { get; set; }

        public Chat Chats { get; set; }
        public User Users { get; set; }

    }
}