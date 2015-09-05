using HumanResource.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Service
{
    public interface IDepartmentService : IService<Department>
    {
        Department GetByName(string departmentName);
        bool IsDepartmentNameExist(string departmentName);
    }
}
