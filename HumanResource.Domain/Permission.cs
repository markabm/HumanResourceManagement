using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Domain
{
    public class Permission : AuditableEntity
    {
        public int PermissionId { get; set; }
        public string PermissionName { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
