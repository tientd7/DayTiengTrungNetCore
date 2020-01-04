using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace Business.Interface
{
    public interface IAccountManager
    {
        CheckLoginDto CheckLogin(LoginDto login);
        string CreateUser(RegisterDto register);
    }
}
