using AutoMapper;
using CFS.Common.BusinessRules;
using CFS.Common.CQRS.Query;
using CFS.Common.Dtos;
using CFS.Common.Enums;
using CFS.Common.Extensions;
using CFS.EventManagement.BusinessRules;
using CFS.EventManagement.Context;
using CFS.EventManagement.Dtos;
using CFS.EventManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFS.EventManagement.Services
{
    public class GetEventsHandler : IQueryHandler<GetEventsByFilterQuery, GetEventsByFilterQuery.Result>
    {
        private readonly ICfsApiContext db;
        private readonly IMapper _mapper;
        private readonly IBusinessRuleSet<GetEventByFilterRuleModel> _ruleSets;
        public GetEventsHandler(ICfsApiContext db, IBusinessRuleSet<GetEventByFilterRuleModel> ruleSets, IMapper mapper)
        {
            this.db = db;
            _ruleSets = ruleSets;
            _mapper = mapper;
        }

        public async Task<GetEventsByFilterQuery.Result> Execute(GetEventsByFilterQuery query)
        {
            var ruleViolations = new List<BusinessRuleResult>() { };
            GetEventByFilterRuleModel ruleModel = _mapper.Map<GetEventByFilterRuleModel>(query);
            Responder responder = db.Responders.FirstOrDefault(res => res.Name.Equals(query.Responder));
            ruleModel.ResponderId = responder?.Id;
            ruleViolations.AddRange(_ruleSets.ExecuteRules(ruleModel).Where(x => x.IsFailed));

            if (ruleViolations.Count > 0)
            {
                var message = ruleViolations
                    .SelectMany(x => x.BusinessRuleResults)
                    .Select(x => x.ErrorMessage)
                    .ConvertExceptionMessage();

                throw new Exception(message);
            }

            IQueryable<Responder> queryResponder = db.Responders;
            IQueryable<CfsEvent> queryEvent = db.Events;
            IQueryable<User> queryUser = db.Users;
            if (!string.IsNullOrWhiteSpace(query.Responder))
            {
                var textSearch = query.Responder.Trim();
                queryResponder = db.Responders.Where(w => w.Name.Contains(textSearch));
            }

            if (query.EventTime != null)
            {
                queryEvent = queryEvent.Where(e => e.EventTime >= query.EventTime);
            }

            if (query.DispatchTime != null)
            {
                queryEvent = queryEvent.Where(e => e.DispatchTime <= query.DispatchTime);
            }

            if (!string.IsNullOrWhiteSpace(query.User))
            {
                var textSearch = query.User.Trim();
                queryUser = db.Users.Where(w => w.UserName.Contains(textSearch));
            }

            var responders = queryResponder;
            var events = queryEvent;
            var users = queryUser;

            var models = (from e in events
                          join u in users on e.UserId equals u.Id
                          join r in responders on e.ResponderId equals r.Id
                          join evn in db.EventTypes on e.EventTypeId equals evn.Id
                          select new GetEventResponse
                          {
                              AgencyId = u.AgencyId.ToString(),
                              DispatchTime = e.DispatchTime,
                              EventId = e.Id.ToString(),
                              EventNumber = e.EventNumber,
                              EventTime = e.EventTime,
                              EventTypeCode = evn.Name,
                              Responder = r.Name,

                          });
            List<GetEventResponse> responses;
            if (query.SortType == SortType.Ascending)
            {
                responses = models.OrderBy(x => x.Responder)
                                  .Paging(query.PageIndex, query.ItemsPerPage).ToList();
            }
            else
            {
                responses = models.OrderByDescending(x => x.Responder)
                      .Paging(query.PageIndex, query.ItemsPerPage).ToList();
            }

            return new GetEventsByFilterQuery.Result
            {
                Data = new PagedItemList<GetEventResponse>(responses)
                {
                    ItemsPerPage = query.ItemsPerPage,
                    PageIndex = query.PageIndex,
                    TotalItems = models.Count()
                }
            };
        }
    }

    public class GetEventsByFilterQuery : LightQuery, IQuery<GetEventsByFilterQuery.Result>
    {
        public string Responder { get; set; }
        public string User { get; set; }
        public DateTime? EventTime { get; set; }
        public DateTime? DispatchTime { get; set; }
        public class Result
        {
            public PagedItemList<GetEventResponse> Data { get; set; }
        }
    }
}
