using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class CategoryPost : BaseEntity
    {
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}
