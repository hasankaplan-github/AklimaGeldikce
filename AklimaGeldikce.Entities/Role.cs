using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class Role : BaseEntity
    {
        public Role()
        {
            RoleUsers = new List<RoleUser>();
            RoleRequests = new List<RoleRequest>();
        }

        public string Name { get; set; }
        public IList<RoleUser> RoleUsers { get; set; }
        public IList<RoleRequest> RoleRequests { get; set; }
    }
}
