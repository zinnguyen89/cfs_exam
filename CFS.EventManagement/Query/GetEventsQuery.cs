using CFS.Common.CQRS.Query;
using CFS.Common.Dtos;
using CFS.EventManagement.Dtos;
using System;

namespace CFS.EventManagement.Query
{
    public class GetEventsQuery : LightQuery, IQuery<GetEventsQuery.Result>
    {
        public class Result
        {
            public PagedItemList<GetEventResponse> Data { get; set; }
        }
    }
}
