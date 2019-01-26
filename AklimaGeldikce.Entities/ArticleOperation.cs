using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class ArticleOperation : BaseEntity
    {
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
        public Guid ArticleStatePathId { get; set; }
        public ArticleStatePath ArticleStatePath { get; set; }
        public DateTime OperationDate { get; set; }
        public Guid? OperatorUserId { get; set; }
        public User OperatorUser { get; set; }
        public Guid? AcceptingUserId { get; set; } 
        public User AcceptingUser { get; set; } // makaleyi üstüne alan(kabul eden, atanan) kullanıcı
                                                /* üstüme aldığım makaleler:
                                                 * group by ArticleId
                                                 * where OperationDate = max
                                                 * and AcceptingUserId = userId
                                                 */

    }
}
