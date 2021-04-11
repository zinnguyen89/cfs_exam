using CFS.Common.Enums;
using System.Collections.Generic;

namespace CFS.Common.CQRS.Query
{
    public class SortItem
    {
        public string Property { get; set; }
        public SortType SortType { get; set; }
    }
    public class LightQuery
    {
        const int pageIndexDefault = 1;
        const int itemsPerPageDefault = 10;
        public string Text { get; set; }
        public int PageIndex { get; set; } = pageIndexDefault;
        public short ItemsPerPage { get; set; } = itemsPerPageDefault;
        public SortType SortType { get; set; } = SortType.Descending;
    }
}
