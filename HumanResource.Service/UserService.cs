using HumanResource.Data.EntityFramework;
using HumanResource.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Service
{
    public class UserService : EntityService<User>,IUserService
    {
        private IContext _context;

        public UserService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = context.Set<User>();
        }

        public User GetByName(string userName)
        {
            return _dbset.FirstOrDefault(x => x.UserName == userName);
        }
               
    }
}
