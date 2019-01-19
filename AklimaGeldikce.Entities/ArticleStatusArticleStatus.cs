using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class ArticleStatusArticleStatus : BaseEntity
    {
        public Guid ParentArticleStatusId { get; set; }
        public ArticleStatus ParentArticleStatus { get; set; }

        public Guid ChildArticleStatusId { get; set; }
        public ArticleStatus ChildArticleStatus { get; set; }
    }
}
