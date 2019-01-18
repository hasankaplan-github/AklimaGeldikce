using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public Guid? OwnerArticleId { get; set; }
        public Article OwnerArticle { get; set; }
        public Guid? OwnerId { get; set; }
        public User Owner { get; set; }
    }
}
