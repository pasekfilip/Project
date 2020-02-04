using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace ChatClient
{
    class Object
    {
        public Object(HttpClient lmao, HttpContent message)
        {
            this.httpClient = lmao;
            this.message = message;
        }
        public HttpClient httpClient { get; set; }
        public HttpContent message { get; set; }
    }
}
