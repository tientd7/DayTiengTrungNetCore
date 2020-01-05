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
        string ChangePassword(string UserName, ChangePassDto changePass);
        string ResetPassword(ResetPassword reset);
        IEnumerable<UserDto> GetAll(bool? isVip, bool? enable);
        UserDto GetByUserName(string userName);
        string UpdateUser(UserDto user);
    }
}
