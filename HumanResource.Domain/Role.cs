﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Domain
{
    public class Role : AuditableEntity
    {
        public int RoleId { get; set; }

        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string RoleName { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
