using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Interface
{
    public interface IAccountRepository
    {
        bool CheckLogin(string userName, string password, out string message, out ApplicationUser user, out IList<String> roles);
        string CreateUser(ApplicationUser CreateUser);
        IQueryable<ApplicationUser> GetAll(Expression<Func<ApplicationUser, bool>> expression);
        
    }
}
