using Business.Interface;
using DAL;
using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Business
{
    public class AccountManager : IAccountManager
    {
        private readonly IAccountRepository _account;
        public AccountManager(IAccountRepository account)
        {
            _account = account;
        }
        public CheckLoginDto CheckLogin(LoginDto login)
        {
            string message = "";
            IList<string> roles;
            CheckLoginDto checkLogin = new CheckLoginDto();
            ApplicationUser user;
            var check = _account.CheckLogin(login.Username, login.Password, out message, out user, out roles);
            checkLogin.Message = message;
            if (!check)
                return checkLogin;
            checkLogin.IsVip = user.IsVip;
            checkLogin.UserName = user.UserName;
            checkLogin.VipExp = user.VipExp;
            checkLogin.Roles = new string[roles.Count];
            roles.CopyTo(checkLogin.Roles,0);

            return checkLogin;
        }

        
    }
}
