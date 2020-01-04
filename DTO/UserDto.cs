using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class UserDto
    {
        public string UserName { set; get; }
        public string Email { set; get; }
    }
    public class RegisterDto
    {
        public string UserName { set; get; }
        public string Password { set; get; }
        public string ConfirmPassword { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
    }
    
}
