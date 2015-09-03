using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResource.Data.EntityFramework;
using HumanResource.Domain;

namespace HumanResource.Service
{
    public class RoleService : EntityService<Role>,IRoleService
    {
        private IContext _context;

        public RoleService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<Role>();
        }

        public Role GetByName(string RoleName)
        {
            return _dbset.FirstOrDefault(x => x.RoleName == RoleName);
        }
    }
}
