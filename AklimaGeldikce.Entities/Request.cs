using System;
using System.Collections.Generic;

namespace AklimaGeldikce.Entities
{
    public class Request : BaseEntity
    {
        public Request()
        {
            this.RoleRequests = new List<RoleRequest>();
        }

        public string Controller { get; set; }
        public string Action { get; set; }
        public IList<RoleRequest> RoleRequests { get; set; }
    }
}
