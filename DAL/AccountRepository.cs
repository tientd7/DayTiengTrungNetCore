using DAL.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class AccountRepository : IAccountRepository
    {
        public static string MSG_CouldNotFoundTheUser = "Không tồn tại tên đăng nhập này!";
        public static string MSG_WrongPwd = "Sai mật khẩu!";
        public static string MSG_Disable = "Tài khoản bị khóa!";
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signinManager)
        {
            _signinManager = signinManager;
            _userManager = userManager;
        }
        public bool CheckLogin(string userName, string password, out string message, out ApplicationUser user, out IList<String> roles)
        {
            roles = null;
            user = _userManager.FindByNameAsync(userName).Result;
            if(user==null)
            {
                message = MSG_CouldNotFoundTheUser;
                return false;
            }
            if (!user.IsEnable)
            {
                message = MSG_Disable;
                return false;
            }
            var check = _signinManager.CheckPasswordSignInAsync(user, password, false).Result;
            if(!check.Succeeded)
            {
                message = MSG_WrongPwd;
                return false;
            }
            roles = _userManager.GetRolesAsync(user).Result;
            message = "";
            return true;
        }
    }
}
