using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace DataAccessLayer
{
    public interface IUserRepository
    {

        bool ValidateLogin(string userName, string password);
        ClaimsPrincipal Get(string userName);
    }
}
