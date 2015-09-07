using HumanResource.Data.EntityFramework;
using HumanResource.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Service
{
    public class AuthenticationService : EntityService<User>, HumanResource.Service.IAuthenticationService
    {
        private IContext _context;
        private IUserPasswordHashService _userpasswordService;

        public AuthenticationService(IContext context, IUserPasswordHashService userpasswordService)
            : base(context)
        {
            _context = context;
            _dbset = context.Set<User>();
            _userpasswordService = userpasswordService;
        }

        public bool HasValidUsernameAndPassword(string userName, string password)
        {
            var user = _dbset.FirstOrDefault(u => u.UserName == userName);
            
            if (user==null)
            {
                return false;
            }

            var userPassword = user.PasswordHash;

            if (_userpasswordService.VerifyHashedPassword(userPassword, password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
