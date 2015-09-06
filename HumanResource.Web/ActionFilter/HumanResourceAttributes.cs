using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web.Routing;

namespace HumanResource.Web.ActionFilter
{
    public class HumanResourceAttributes : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                //Create permission string based on the requested controller name and action name in the format 'controllername-action'
                string requiredPermission = String.Format("{0}-{1}", filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, filterContext.ActionDescriptor.ActionName);
                base.OnAuthorization(filterContext);
                //Create an instance of our custom user authorization object passing requesting user's identity id into constructor
                //PMUser requestingUser = new PMUser(filterContext.RequestContext.HttpContext.User.Identity.GetUserId<int>());

                //Check if the requesting user has the permission to run the controller's action
                //if (!requestingUser.HasPermission(requiredPermission))
                //{
                //    //User doesn't have the required permission, return our custom “401 Unauthorized” access error
                //    //Since we are setting filterContext.Result to contain an ActionResult page, the controller's action will not be run.
                //    //The custom “401 Unauthorized” access error will be returned to the browser in response to the initial request.
                //    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "action", "Index" }, { "controller", "Unauthorized" } });
                //}
                //else
                //{
                //    base.OnAuthorization(filterContext);
                //}
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "action", "Login" }, { "controller", "AccountLogin" } });
            }
        }
    }
}