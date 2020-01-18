using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Tables
{
    [Table("Chats")]
    public class Chat
    {
        [Key]
        public int ID { get; set; }
        public string Picture { get; set; }
        [ForeignKey("Users")]
        public int? ID_Admin { get; set; }

        //public virtual User Users { get; set; }
        public User Users { get; set; }
    }
}