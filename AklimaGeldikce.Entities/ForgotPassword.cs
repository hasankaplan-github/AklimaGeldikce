using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class ForgotPassword : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public bool IsUsed { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
