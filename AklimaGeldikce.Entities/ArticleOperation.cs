using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class ArticleOperation : BaseEntity
    {
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
        public Guid ArticleStatusId { get; set; }
        public ArticleStatus ArticleStatus { get; set; }
        public DateTime OperationDate { get; set; }
        public Guid OperationUserId { get; set; }
        public User OperationUser { get; set; }
        public Guid AcceptingUserId { get; set; } // makaleyi üstüne alan(kabul eden, atanan) kullanıcı
        /* üstüme aldığım makaleler:
         * group by ArticleId
         * where max OperationDate
         * and AcceptingUserId = userId
         */ 

    }
}
