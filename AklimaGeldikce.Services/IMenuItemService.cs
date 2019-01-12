using AklimaGeldikce.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AklimaGeldikce.Services
{
    public interface IMenuItemService : IBaseService<MenuItem>
    {
        Task<string> GetNavbarHtmlAsync(Guid? parentMenuItemId, IList<Role> roles, bool isDropdownItem);
    }
}
