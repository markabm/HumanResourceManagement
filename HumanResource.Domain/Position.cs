using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Domain
{
    public class Position : AuditableEntity
    {
        public int PositionId { get; set; }

        public string PositionName { get; set; }

        public int PositionNoEmployee { get; set; }

        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}
