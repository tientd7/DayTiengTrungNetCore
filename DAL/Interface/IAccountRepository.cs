using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface IAccountRepository
    {
        bool CheckLogin(string userName, string password, out string message, out ApplicationUser user, out IList<String> roles);
    }
}
