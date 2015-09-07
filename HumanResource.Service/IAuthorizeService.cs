using System;
namespace HumanResource.Service
{
    public interface IAuthorizeService
    {
        bool HasPermission(int roleId, string permissionName);
    }
}
