using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebAPI.Models.Tables;

namespace WebAPI.Models
{
    [DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]
    public class MyContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Friends> Friends { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Chat_Member> Chat_Members { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<File> Files { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}