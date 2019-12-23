using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Models.Tables;

namespace WebAPI.Controllers
{
    public class FileController : ApiController
    {
        private FileRepository repository = new FileRepository();

        [Route("api/Files")]
        [HttpGet]
        public List<File> Get()
        {
            return this.repository.FindAll();
        }


        [Route("api/File/{id}")]
        [HttpGet]
        public File Get(int id)
        {
            return this.repository.FindById(id);
        }

        [Route("api/Files")]
        [HttpPost]
        public void Post([FromBody]File value)
        {
            this.repository.Create(value);
        }


        //[Route("api/File/{id}")]
        //[HttpPost]
        //public void Put(int id, [FromBody]File value)
        //{
        //    value.ID = id;
        //    this.repository.Update(value, id);
        //}


        [Route("api/File/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            File file = this.repository.FindById(id);
            this.repository.Delete(file);
        }
    }
}
