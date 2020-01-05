using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Tables
{
    [Table("Messages")]
    public class Message
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Users")]
        public int ID_User { get; set; }
        [Column("Message")]
        public string TheMessage { get; set; }
        [ForeignKey("Chats")]
        public int ID_Chat { get; set; }
        public DateTime Send_Time { get; set; }
        public DateTime Del_Msg_Time { get; set; }
        [InverseProperty("Messages")]
        public virtual User Users { get; set; }
        public Chat Chats { get; set; }
    }
}