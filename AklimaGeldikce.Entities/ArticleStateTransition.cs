using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class ArticleStateTransition : BaseEntity
    {
        public Guid? SourceArticleStateId { get; set; }
        public ArticleState SourceArticleState { get; set; }

        public Guid? DestinationArticleStateId { get; set; }
        public ArticleState DestinationArticleState { get; set; }

        public Guid ArticleActionId { get; set; }
        public ArticleAction ArticleAction { get; set; }
    }
}
