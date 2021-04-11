using System;
using System.Collections.Generic;
using System.Linq;

namespace CFS.Common.Dtos
{
    public interface IPagingInfo<T>
    {
        int PageIndex { get; set; }

        short ItemsPerPage { get; set; }

        int TotalItems { get; set; }

        int TotalPages { get; }
        List<T> Results { get; set; }
    }

    public class PagedItemList<T> : IPagingInfo<T>
    {
        public PagedItemList(IEnumerable<T> items)
        {
            var collection = items.ToList();
            Results = new List<T>(collection);
            TotalItems = collection.Count();
        }
        public List<T> Results { get; set; }
        public int PageIndex { get; set; }

        public short ItemsPerPage { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages => ItemsPerPage == 0 ? 0 : (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}
