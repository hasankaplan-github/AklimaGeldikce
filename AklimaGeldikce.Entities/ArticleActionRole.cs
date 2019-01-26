using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class ArticleActionRole : BaseEntity
    {
        public Guid ArticleActionId { get; set; }
        public ArticleAction ArticleAction { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
