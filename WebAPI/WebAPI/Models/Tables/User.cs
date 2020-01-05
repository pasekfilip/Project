using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebAPI.Models.Tables
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }

        public virtual ICollection<Friends> Friends { get; set; }
        public virtual ICollection<Friends> Users { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        //public virtual ICollection<Chat> Chats { get; set; }

    }
}