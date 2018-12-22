using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class RoleMenuItem : BaseEntity
    {
        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public Guid MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
