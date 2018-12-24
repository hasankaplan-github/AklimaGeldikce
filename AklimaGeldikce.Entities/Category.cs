using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            this.ChildCategories = new List<Category>();
            this.CategoryPosts = new List<CategoryPost>();
        }

        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public IList<Category> ChildCategories { get; set; }
        public IList<CategoryPost> CategoryPosts { get; set; }
    }
}
