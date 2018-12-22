using System;
using System.Collections.Generic;

namespace AklimaGeldikce.Entities
{
    public class Post : BaseEntity
    {
        public Post()
        {
            this.Comments = new List<Comment>();
            this.CategoryPosts = new List<CategoryPost>();
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public IList<Comment> Comments { get; set; }
        public Guid OwnerId { get; set; }
        public User Owner { get; set; }
        public IList<CategoryPost> CategoryPosts { get; set; }
        public int ViewCount { get; set; }
    }
}
