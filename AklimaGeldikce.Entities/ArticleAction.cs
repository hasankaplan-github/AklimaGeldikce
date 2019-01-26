using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class ArticleAction : BaseEntity
    {
        public ArticleAction()
        {
            ArticleActionRoles = new List<ArticleActionRole>();
            ArticleStatePaths = new List<ArticleStatePath>();
        }

        public string CodeName { get; set; }
        public string Description { get; set; }
        public IList<ArticleActionRole> ArticleActionRoles { get; set; }
        public IList<ArticleStatePath> ArticleStatePaths { get; set; }
    }
}
