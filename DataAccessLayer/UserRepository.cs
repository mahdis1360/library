using Microsoft.VisualBasic;
using poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;


namespace DataAccessLayer
{
    public class UserRepository : IUserRepository
    {
        private readonly LoginPoco _user;
        public static Guid AuthorloginId;
        List<LoginPoco> _users = new List<LoginPoco>
        {
            new LoginPoco { Username = "barryd",  Role = "Administrator" },
            new LoginPoco { Username = "Darth Vader"},
            new LoginPoco { Username = "dedward", Role = "Administrator" }
        };
        public UserRepository()
        {
            _user = new LoginPoco();
        }

        public ClaimsPrincipal Get(string userName)
        {


            if (_user.Username.ToUpperInvariant() != userName.ToUpperInvariant())
            {
                return null;
            }

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, userName, ClaimValueTypes.String));

            if (!string.IsNullOrWhiteSpace(_user.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, _user.Role, ClaimValueTypes.String));
            }

            var userIdentity = new ClaimsIdentity("AuthorizationLab");
            userIdentity.AddClaims(claims);

            var userPrincipal = new ClaimsPrincipal(userIdentity);

            return userPrincipal;
        }

        public bool ValidateLogin(string userName, string password)
        {
            if (_user.Username.ToUpperInvariant() == userName.ToUpperInvariant())
            {
                AuthorloginId = _user.AutorId;
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}

