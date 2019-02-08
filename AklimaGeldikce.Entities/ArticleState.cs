using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class ArticleState : BaseEntity
    {
        public ArticleState()
        {
            SourceArticleStateTransitions = new List<ArticleStateTransition>();
            DestinationArticleStateTransitions = new List<ArticleStateTransition>();
        }

        public string CodeName { get; set; }
        public string Description { get; set; }
        public IList<ArticleStateTransition> SourceArticleStateTransitions { get; set; }
        public IList<ArticleStateTransition> DestinationArticleStateTransitions { get; set; }
    }
}
