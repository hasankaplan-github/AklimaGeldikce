using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AklimaGeldikce.Entities
{
    public class PagedList<TEntity> : List<TEntity>
    {
        public int PageIndex { get; private set; }
        public int TotalPageCount { get; private set; }

        public bool HasPreviousPage
        {
            get
            {
                return (TotalPageCount>1 && PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (TotalPageCount > 1 && PageIndex < TotalPageCount);
            }
        }

        public PagedList(List<TEntity> pagedItems, int totalItemCount, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPageCount = (int)Math.Ceiling(totalItemCount / (double)pageSize);

            this.AddRange(pagedItems);
        }
    }
}
