using DAL.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL
{
    public class AccountRepository : IAccountRepository
    {
        public static string MSG_CouldNotFoundTheUser = "Không tồn tại tên đăng nhập này!";
        public static string MSG_WrongPwd = "Sai mật khẩu!";
        public static string MSG_Disable = "Tài khoản bị khóa!";
        public static string MSG_Duplicate = "Tài khoản đã tồn tại trong hệ thống!";
        public static string MSG_CreateErr = "Thao tác thất bại, liên hệ quản trị hệ thống!";
        public static string MSG_Success = "Thành công!";

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly IRepository<ApplicationUser> _repository;
        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signinManager, IRepository<ApplicationUser> repository)
        {
            _signinManager = signinManager;
            _userManager = userManager;
            _repository = repository;
        }
        public bool CheckLogin(string userName, string password, out string message, out ApplicationUser user, out IList<String> roles)
        {
            roles = null;
            var check = CheckLogin(userName, password, out message, out user);
            if (!check)
            {
                return false;
            }
            roles = _userManager.GetRolesAsync(user).Result;
            message = "";//empty is success
            return true;
        }
        private bool CheckLogin(string userName, string password, out string message,out ApplicationUser user)
        {
            user = _userManager.FindByNameAsync(userName).Result;
            if (user == null)
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
            if (!check.Succeeded)
            {
                message = MSG_WrongPwd;
                return false;
            }
            message = MSG_Success;
            return true;
        }
        public string CreateUser(ApplicationUser CreateUser, string password)
        {
            string msg = "";
            var user = _userManager.FindByNameAsync(CreateUser.UserName).Result;
            if (user != null)
            {
                msg = MSG_Duplicate;
                return msg;
            }
            try
            {
                IdentityResult result = _userManager.CreateAsync(CreateUser, password).Result;
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(CreateUser, RoleType.User).Wait();
                    msg = MSG_Success;
                }
                else msg = MSG_CreateErr;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                msg = MSG_CreateErr;
                throw new Exception(msg);
            }


            return msg;
        }

        public IQueryable<ApplicationUser> GetAll(Expression<Func<ApplicationUser, bool>> expression)
        {
            return _repository.GetMany(expression);
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword, out string message)
        {
            ApplicationUser user;
            var check = CheckLogin(userName, oldPassword, out message, out user);
            if (!check)
                return false;
            var rst = _userManager.ChangePasswordAsync(user, oldPassword, newPassword).Result;
            if (!rst.Succeeded)
            {
                message = MSG_CreateErr;
                return false;
            }
            message = MSG_Success;
            return true;

        }
    }
}
