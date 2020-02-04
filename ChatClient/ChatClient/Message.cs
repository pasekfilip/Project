using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    public class Message
    {
        public int ID { get; set; }
        public int ID_User { get; set; }
        public string TheMessage { get; set; }
        public int ID_Chat { get; set; }
        public DateTime Send_Time { get; set; }
        public DateTime? Del_Msg_Time { get; set; }

    }
}
