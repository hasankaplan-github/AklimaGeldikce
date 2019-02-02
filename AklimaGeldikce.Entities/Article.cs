using System;
using System.Collections.Generic;

namespace AklimaGeldikce.Entities
{
    public class Article : BaseEntity
    {
        public Article()
        {
            this.Comments = new List<Comment>();
            this.CategoryArticles = new List<CategoryArticle>();
            this.ArticleOperations = new List<ArticleOperation>();
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public IList<Comment> Comments { get; set; }
        public Guid? AuthorId { get; set; }
        public User Author { get; set; }
        public IList<CategoryArticle> CategoryArticles { get; set; }
        public int ViewCount { get; set; }
        public IList<ArticleOperation> ArticleOperations { get; set; }
    }
}
