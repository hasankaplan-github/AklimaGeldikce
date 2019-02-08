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
            ArticleStateTransitions = new List<ArticleStateTransition>();
        }

        public string CodeName { get; set; }
        public string Description { get; set; }
        public IList<ArticleActionRole> ArticleActionRoles { get; set; }
        public IList<ArticleStateTransition> ArticleStateTransitions { get; set; }
    }
}
