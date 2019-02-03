using AklimaGeldikce.Entities;
using AklimaGeldikce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AklimaGeldikce.Web.ActionFilterAttributes
{
    public class AuthorizeActionFilterAttribute : ActionFilterAttribute
    {
        private IUserService userService;
        private IRoleUserService roleUserService;
        private IRequestService requestService;
        private IRoleRequestService roleRequestService;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            this.userService = context.HttpContext.RequestServices.GetService(typeof(IUserService)) as IUserService;
            this.roleUserService = context.HttpContext.RequestServices.GetService(typeof(IRoleUserService)) as IRoleUserService;
            this.requestService = context.HttpContext.RequestServices.GetService(typeof(IRequestService)) as IRequestService;
            this.roleRequestService = context.HttpContext.RequestServices.GetService(typeof(IRoleRequestService)) as IRoleRequestService;

            string controller = context.RouteData.Values["controller"].ToString();
            string action = context.RouteData.Values["action"].ToString();
            string loggedInUserIdCookie = context.HttpContext.Request.Cookies["loggedInUserId"];

            var loggedInUserId = string.IsNullOrEmpty(loggedInUserIdCookie) ? Guid.Empty : Guid.Parse(loggedInUserIdCookie);
            context.HttpContext.Response.Cookies.Append("loggedInUserId", loggedInUserId.ToString());
            var roleUsers = this.roleUserService.GetMany(ru => ru.UserId == loggedInUserId);
            var request = this.requestService.Get(r => r.Action.Equals(action) && r.Controller.Equals(controller));
            var roleRequests = request == null ? new List<RoleRequest>() : this.roleRequestService.GetMany(rr => rr.RequestId == request.Id);

            bool isAuthorized = false;
            IList<Guid> userRoleIds = new List<Guid>(roleUsers.Count + 1); //+1 for guest roleId
            userRoleIds.Add(Guid.Empty); // add guest roleId
            foreach (var roleUser in roleUsers)
            {
                userRoleIds.Add(roleUser.RoleId);
            }

            foreach (var roleRequest in roleRequests)
            {
                if(userRoleIds.Contains(roleRequest.RoleId))
                {
                    isAuthorized = true;
                    break;
                }
            }
            
            if (isAuthorized == false)
            {
                //context.HttpContext.Response.Redirect("/Account/Login");

                // Prevent the action from actually being executed
                context.Result = new RedirectResult("/Account/Login?returnUrl=/" + controller + "/" + action);
            }

            base.OnActionExecuting(context);
        }
    }
}
