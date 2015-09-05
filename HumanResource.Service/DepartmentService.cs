using HumanResource.Data.EntityFramework;
using HumanResource.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Service
{
    public class DepartmentService : EntityService<Department>, IDepartmentService
    {
        private IContext _context;

        public DepartmentService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<Department>();
        }

        public Department GetByName(string departmentName)
        {
            return _dbset.FirstOrDefault(x => x.DepartmentName == departmentName);
        }

        public bool IsDepartmentNameExist(string departmentName)
        {
            var department = _dbset.FirstOrDefault(x => x.DepartmentName == departmentName);
            if (department!=null)
                return true;

            return false;
        }
    }
}
