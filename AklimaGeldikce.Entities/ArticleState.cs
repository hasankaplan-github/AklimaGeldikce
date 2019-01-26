using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class ArticleState : BaseEntity
    {
        public ArticleState()
        {
            SourceArticleStatePaths = new List<ArticleStatePath>();
            DestinationArticleStatePaths = new List<ArticleStatePath>();
        }

        public string CodeName { get; set; }
        public string Description { get; set; }
        public IList<ArticleStatePath> SourceArticleStatePaths { get; set; }
        public IList<ArticleStatePath> DestinationArticleStatePaths { get; set; }
    }
}
