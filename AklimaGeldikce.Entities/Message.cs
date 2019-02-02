using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class Message : BaseEntity
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public Guid FromId { get; set; }
        public User From { get; set; }
        public Guid ToId { get; set; }
        public User To { get; set; }
        public bool IsRead { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
