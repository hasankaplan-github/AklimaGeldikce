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
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public IList<Comment> Comments { get; set; }
        public Guid? OwnerId { get; set; }
        public User Owner { get; set; }
        public IList<CategoryArticle> CategoryArticles { get; set; }
        public int ViewCount { get; set; }
    }
}
