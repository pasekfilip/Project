using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Tables
{
    [Table("Files")]
    public class File
    {
        [Key,ForeignKey("Message")]
        public int ID_Message { get; set; }
        [Column("File")]
        public string TheFile { get; set; }

        public Message Message { get; set; }
    }
}