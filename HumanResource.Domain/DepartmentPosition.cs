using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Domain
{
    public class DepartmentPosition
    {
        public int DepartmentPositionId { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
    }
}
