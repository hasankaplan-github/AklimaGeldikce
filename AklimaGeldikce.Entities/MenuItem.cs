using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class MenuItem : BaseEntity
    {
        public MenuItem()
        {
            this.ChildMenuItems = new List<MenuItem>();
            this.RoleMenuItems = new List<RoleMenuItem>();
        }

        public string Name { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public Guid ParentMenuItemId { get; set; }
        public MenuItem ParentMenuItem { get; set; }
        public IList<MenuItem> ChildMenuItems { get; set; }
        public int Order { get; set; }
        public IList<RoleMenuItem> RoleMenuItems { get; set; }
    }
}
