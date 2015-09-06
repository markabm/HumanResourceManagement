using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Domain
{
    public class Department : AuditableEntity
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
    }
}
