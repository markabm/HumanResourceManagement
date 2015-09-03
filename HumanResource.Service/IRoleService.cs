using HumanResource.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Service
{
    public interface IRoleService : IService<Role>
    {
        Role GetByName(string RoleName);
    }
}
