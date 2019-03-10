using AklimaGeldikce.Entities;
using AklimaGeldikce.Repositories;
using AklimaGeldikce.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AklimaGeldikce.Services
{
    public class MenuItemService : BaseService<MenuItem>, IMenuItemService
    {
        private readonly IBaseRepository<RoleMenuItem> roleMenuItemRepository;

        public MenuItemService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.roleMenuItemRepository = unitOfWork.GetRepository<RoleMenuItem>();
        }

        public async Task<string> GetNavbarHtmlAsync(Guid? parentMenuItemId, IList<Role> roles, bool isDropdownItem)
        {
            string menu = "";

            var roleIds = new List<Guid>(roles.Count);
            foreach (var role in roles)
            {
                roleIds.Add(role.Id);
            }

            var menuItems = await base.repository.GetManyAsync(mi => mi.ParentMenuItemId == parentMenuItemId, q => q.OrderBy(e => e.Order));
            foreach (var menuItem in menuItems)
            {
                var roleMenuItems = await this.roleMenuItemRepository.GetManyAsync(rmi => rmi.MenuItemId == menuItem.Id);
                foreach (var roleMenuItem in roleMenuItems)
                {
                    if (roleIds.Contains(roleMenuItem.RoleId))
                    {
                        var childMenuItems = await base.repository.GetManyAsync(mi => mi.ParentMenuItemId == menuItem.Id);
                        if (menuItem.ChildMenuItems != null && menuItem.ChildMenuItems.Count > 0)
                        {
                            menu += "<li class=\"nav-item dropdown\">" +
                                        "<a class=\"nav-link dropdown-toggle\" href=\"#\" id=\"navbarDropdown\" role=\"button\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">" +
                                            menuItem.Name +
                                        "<span class=\"caret\"></span>" +
                                        "</a>" +
                                        "<ul class=\"dropdown-menu\" aria-labelledby=\"navbarDropdown\">" +
                                            await GetNavbarHtmlAsync(menuItem.Id, roles, true) +
                                        "</ul>" +
                                    "</li>";
                        }
                        else //if (isDropdownItem == false)
                        {
                            menu += "<li class=\"nav-item\"><a asp-area=\"\" href=\"/" + menuItem.Controller + "/" + menuItem.Action + "\" class=\"nav-link\">" + menuItem.Name + "</a></li>";
                        }
                        /*
                        else
                        {
                            menu += "<a asp-area=\"\" href=\"/" + menuItem.Controller + "/" + menuItem.Action + "\" class=\"dropdown-item\">" + menuItem.Name + "</a>";
                        }
                        */
                        break;
                    }
                }
            }

            return menu;
        }

        public async Task<string> GetSidebarHtmlAsync(Guid? parentMenuItemId, IList<Role> roles)
        {
            string menu = "";

            var roleIds = new List<Guid>(roles.Count);
            foreach (var role in roles)
            {
                roleIds.Add(role.Id);
            }

            var menuItems = await base.repository.GetManyAsync(mi => mi.ParentMenuItemId == parentMenuItemId, q => q.OrderBy(e => e.Order));
            foreach (var menuItem in menuItems)
            {
                var roleMenuItems = await this.roleMenuItemRepository.GetManyAsync(rmi => rmi.MenuItemId == menuItem.Id);
                foreach (var roleMenuItem in roleMenuItems)
                {
                    if (roleIds.Contains(roleMenuItem.RoleId))
                    {
                        var childMenuItems = await base.repository.GetManyAsync(mi => mi.ParentMenuItemId == menuItem.Id);
                        if (menuItem.ChildMenuItems != null && menuItem.ChildMenuItems.Count > 0)
                        {
                            menu += "<li class=\"treeview\">" +
                                        "<a href = \"#\" >" +
                                            "<i class=\"fa fa-share\"></i> <span>" + menuItem.Name + "</span>" +
                                            "<span class=\"pull-right-container\">" +
                                                "<i class=\"fa fa-angle-left pull-right\"></i>" +
                                            "</span>" +
                                        "</a>" +
                                        "<ul class=\"treeview-menu\">" +
                                            await GetSidebarHtmlAsync(menuItem.Id, roles) +
                                        "</ul>" +
                                    "</li>";
                        }
                        else
                        {
                            menu += "<li><a href=\"/" + menuItem.Controller + "/" + menuItem.Action + "\" ><i class=\"fa fa-circle-o\"></i>" + menuItem.Name + "</a></li>";
                        }
                        
                        break;
                    }
                }
            }

            return menu;
        }
    }
}
