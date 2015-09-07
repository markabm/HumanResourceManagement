using HumanResource.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HumanResource.Web.Controllers
{
    public class AuthorizationController : Controller
    {
        private IAuthorizeService _authorizeService;

        public AuthorizationController(IAuthorizeService authorizeService)
        {
            _authorizeService = authorizeService;
        }

        public bool HasPermission(int roleId,string permissionName)
        {
            return _authorizeService.HasPermission(roleId,permissionName);
        }
    }
}