using AklimaGeldikce.Entities;
using AklimaGeldikce.Services;
using AklimaGeldikce.Web.Code;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AklimaGeldikce.Web.ViewComponents
{
    public class SideBarViewComponent : ViewComponent
    {
        private readonly IRoleService roleService;
        private readonly IMenuItemService menuItemService;

        public SideBarViewComponent(IRoleService roleService, IMenuItemService menuItemService)
        {
            this.roleService = roleService;
            this.menuItemService = menuItemService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string dynamicSidebarCookie = Request.Cookies[CookieKeys.DynamicSideBar];
            if (string.IsNullOrEmpty(dynamicSidebarCookie))
            {
                var roles = await this.roleService.GetManyAsync(r => r.Name == "Guest");
                dynamicSidebarCookie = await this.menuItemService.GetSidebarHtmlAsync(null, roles);
                HttpContext.Response.Cookies.Append(CookieKeys.DynamicSideBar, dynamicSidebarCookie);
            }
            return View("Default_AdminLte", dynamicSidebarCookie);
        }
    }
}
