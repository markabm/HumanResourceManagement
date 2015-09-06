using HumanResource.Data.EntityFramework;
using HumanResource.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Service
{
    public class AuthorizeService : EntityService<RolePermission>
    {
        private IContext _context;

        public AuthorizeService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<RolePermission>();
        }

        //public Permission GetPermissionByRole(int roleId, string permissionName)
        //{
        //    _context.RolePermissions
        //}
    }
}
