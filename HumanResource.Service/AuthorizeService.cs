using HumanResource.Data.EntityFramework;
using HumanResource.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Service
{
    public class AuthorizeService : EntityService<RolePermission>, IAuthorizeService
    {
        private IContext _context;

        public AuthorizeService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<RolePermission>();
        }

        public bool HasPermission(int roleId, string permissionName)
        {
            var permission = (from rp in _context.RolePermissions
                             join r in _context.Roles on rp.RoleId equals r.RoleId
                             join p in _context.Permissions on rp.PermissionId equals p.PermissionId
                             where rp.RoleId == roleId && p.PermissionName == permissionName
                             select p).FirstOrDefault();

            if (permission != null)
                return true;
            else
                return false;
        }
    }
}
