using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AklimaGeldikce.Services;
using AklimaGeldikce.Web.Code;
using Microsoft.AspNetCore.Mvc;

namespace AklimaGeldikce.Web.Controllers
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly IMenuService menuService;
        private readonly IRoleService roleService;

        public HeaderViewComponent(IMenuService menuService, IRoleService roleService)
        {
            this.menuService = menuService;
            this.roleService = roleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string dynamicSidebarCookie = Request.Cookies[CookieKeys.DynamicSideBar];
            if (string.IsNullOrEmpty(dynamicSidebarCookie))
            {
                var roles = await this.roleService.GetManyAsync(r => r.Name == "Guest");
                dynamicSidebarCookie = await this.menuService.GetSidebarHtmlAsync(null, roles);
                HttpContext.Response.Cookies.Append(CookieKeys.DynamicSideBar, dynamicSidebarCookie);
            }
            return View("Default_AdminLte", dynamicSidebarCookie);
        }
    }
}