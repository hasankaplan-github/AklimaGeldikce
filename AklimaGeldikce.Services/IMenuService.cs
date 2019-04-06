using AklimaGeldikce.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AklimaGeldikce.Services
{
    public interface IMenuService
    {
        Task<string> GetNavbarHtmlAsync(Guid? parentMenuItemId, IList<Role> roles, bool isDropdownItem);
        Task<string> GetSidebarHtmlAsync(Guid? parentMenuItemId, IList<Role> roles);
        IList<MenuItem> GetAllMenuItems();
        MenuItem GetMenuItemById(Guid? id);
        void CreateMenuItem(MenuItem menuItem);
        void UpdateMenuItem(MenuItem menuItem);
        void DeleteMenuItem(Guid id);
        bool ExistsMenuItem(Expression<Func<MenuItem, bool>> predicate);
    }
}
