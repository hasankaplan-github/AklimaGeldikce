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
            ArticleActionRoles = new List<ArticleActionRole>();
        }

        public string Name { get; set; }
        public IList<RoleUser> RoleUsers { get; set; }
        public IList<RoleRequest> RoleRequests { get; set; }
        public IList<ArticleActionRole> ArticleActionRoles { get; set; }
    }
}
