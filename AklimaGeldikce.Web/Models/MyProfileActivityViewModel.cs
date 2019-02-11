using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AklimaGeldikce.Web.Models
{
    public class MyProfileActivityViewModel
    {
        public int PublishedArticleCount { get; set; }
        public int DraftArticleCount { get; set; }
        public int RejectedArticleCount { get; set; }
        public int ReviewingArticleCount { get; set; }
    }
}
