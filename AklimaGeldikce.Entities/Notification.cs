using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class Notification : BaseEntity
    {
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public Guid ToId { get; set; }
        public User To { get; set; }
        public DateTime NotificationDate { get; set; }
    }
}
