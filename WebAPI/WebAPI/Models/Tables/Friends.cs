using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Tables
{
    public class Friends
    {
        [Key, ForeignKey("User"), Column(Order = 0)]
        public int ID_User { get; set; }

        [Key, ForeignKey("Friend"), Column(Order = 1)]
        public int ID_Friend { get; set; }

        [InverseProperty("Users")]
        public virtual User User { get; set; }
        [InverseProperty("Friends")]
        public virtual User Friend { get; set; }

    }
}