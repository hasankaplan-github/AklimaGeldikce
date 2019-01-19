using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class ArticleStatus : BaseEntity
    {
        public ArticleStatus()
        {
            this.ArticleOperations = new List<ArticleOperation>();
            this.ChildArticleStatusArticleStatuses = new List<ArticleStatusArticleStatus>();
            this.ParentArticleStatusArticleStatuses = new List<ArticleStatusArticleStatus>();
        }

        public string Name { get; set; }
        public IList<ArticleStatusArticleStatus> ChildArticleStatusArticleStatuses { get; set; }
        public IList<ArticleStatusArticleStatus> ParentArticleStatusArticleStatuses { get; set; }
        public IList<ArticleOperation> ArticleOperations { get; set; }
    }
}
