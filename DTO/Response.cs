using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Response
    {
        public Response(string status, string msg)
        {
            this.status = status;
            title = msg;
        }
        public string title { set; get; }
        public string status { set; get; }
    }
}
