using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
