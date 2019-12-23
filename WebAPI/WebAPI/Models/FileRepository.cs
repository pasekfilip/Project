using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models.Tables;

namespace WebAPI.Models
{
    public class FileRepository
    {
        private MyContext context = new MyContext();

        public List<File> FindAll()
        {
            return this.context.Files.ToList();
        }

        public File FindById(int id)
        {
            //return this.context.Chat.Where(x => x.Id == id).FirstOrDefault();
            return this.context.Files.Find(id);
        }

        public void Create(File file)
        {
            this.context.Files.Add(file);
            this.context.SaveChanges();
        }

        public void Update(Message file, int id)
        {
            File entity = this.FindById(id);
            if (entity == null)
                return;
            context.Entry(entity).CurrentValues.SetValues(file);
            context.SaveChanges();
        }

        public void Delete(File file)
        {
            this.context.Files.Remove(file);
            this.context.SaveChanges();
        }
    }
}