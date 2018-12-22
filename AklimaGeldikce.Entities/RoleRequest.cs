using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class RoleRequest : BaseEntity
    {
        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public Guid RequestId { get; set; }
        public Request Request { get; set; }
    }
}
