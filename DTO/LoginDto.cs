using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class LoginDto
    {
        public string Username { set; get; }
        public string Password { set; get; }
    }

    public class CheckLoginDto
    {
        public string UserName { set; get; }
        public string[] Roles { set; get; }
        public bool IsVip { set; get; }
        public DateTime? VipExp { set; get; }
        public string Message { set; get; }
        public string Token { set; get; }
    }
}
