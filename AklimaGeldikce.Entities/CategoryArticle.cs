using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class CategoryArticle : BaseEntity
    {
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
