using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class RoleUser : BaseEntity
    {
        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
