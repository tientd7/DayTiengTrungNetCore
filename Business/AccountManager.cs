using Business.Interface;
using DAL;
using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
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

        public string ChangePassword(string UserName, ChangePassDto changePass)
        {
            if (!changePass.Password.Equals(changePass.ConfirmPassword))
                throw new Exception("Mật khẩu mới xác nhận không đúng!");
            string msg;
            var check = _account.ChangePassword(UserName, changePass.CurrentPassword, changePass.Password, out msg);
            if (!check)
                throw new Exception(msg);
            return msg;
        }
        public string ResetPassword(ResetPassword reset)
        {
            string msg;
            var check = _account.ResetPassword(reset.PhoneNumber, reset.Email, out msg);
            if (!check)
                throw new Exception(msg);

            return msg;
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

        public string CreateUser(RegisterDto register)
        {
            ApplicationUser user = new ApplicationUser();
            user.UserName = register.PhoneNumber;
            user.PhoneNumber = register.PhoneNumber;
            user.PhoneNumberConfirmed = true;
            user.Email = register.Email;
            user.IsEnable = true;
            return _account.CreateUser(user,register.Password);
        }

        public IEnumerable<UserDto> GetAll(bool? isVip, bool? enable)
        {
            var query = from s in _account.GetAll(t => 
                ((isVip.HasValue && t.IsVip == isVip.Value) || (!isVip.HasValue)) &&
                ((enable.HasValue && t.IsEnable == enable.Value) || (!enable.HasValue))) 
                        
                        select new UserDto()
                        {
                            Email = s.Email,
                            Enable = s.IsEnable,
                            IsVip = s.IsVip,
                            VipExpDate = s.VipExp,
                            PhoneNumber = s.PhoneNumber
                        };
            return query;
        }

        public UserDto GetByUserName(string userName)
        {
            var query = (from s in _account.GetAll(t=>t.UserName.Equals(userName))
                        select new UserDto()
                        {
                            Email = s.Email,
                            Enable = s.IsEnable,
                            IsVip = s.IsVip,
                            VipExpDate = s.VipExp,
                            PhoneNumber = s.PhoneNumber
                        }).FirstOrDefault();
            return query;
        }

        public string UpdateUser(UserDto user)
        {
            var AppUser = _account.FindByName(user.PhoneNumber);
            if(AppUser== null)
            {
                throw new Exception("Không tồn tại tài khoản này!");
            }
            AppUser.Email = user.Email;
            AppUser.PhoneNumber = user.PhoneNumber;
            AppUser.IsEnable = user.Enable;
            AppUser.IsVip = user.IsVip;
            AppUser.VipExp = user.VipExpDate;
            string msg = _account.UpdateUser(AppUser);
            return msg;
        }
    }
}
