using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class AppLevelLog : BaseEntity
    {
        public Guid OwnerId { get; set; }
        public User Owner { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public DateTime LogDate { get; set; }
    }
}
