using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Tables
{
    public class Token
    {
        [Key, Column("Token")]
        [MaxLength]
        public string TheToken { get; set; }
        [ForeignKey("Users")]
        public int ID_User { get; set; }
        public string Expire_time { get; set; }

        public User Users { get; set; }

    }
}