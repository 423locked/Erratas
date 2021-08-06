using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erratas.Models
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int PagesTotal { get; set; }

        /// <summary>
        /// Paginated List of items <T>
        /// </summary>
        /// <param name="items">List of items to be paginated</param>
        /// <param name="count">Amount of elements</param>
        /// <param name="pageIndex">Current paginating index</param>
        /// <param name="pageSize">How many items are going to be displayed on a single paginated page</param>
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PagesTotal = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }

        public bool PreviousPageExists => PageIndex > 1;
        public bool NextPageExists => PageIndex < PagesTotal;

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            int count = await source.CountAsync();
            // skip all the previous entities (index * amount) and take (amount)
            List<T> items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
