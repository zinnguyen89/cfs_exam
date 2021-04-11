using AutoMapper;
using CFS.Common.BusinessRules;
using CFS.Common.CQRS.Command;
using CFS.Common.Extensions;
using CFS.EventManagement.BusinessRules;
using CFS.EventManagement.Commands;
using CFS.EventManagement.Context;
using CFS.EventManagement.Dtos;
using CFS.EventManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFS.EventManagement.Services
{
    public class CreateEventCommandhandler : ICommandHandler<CreateEventCommand, CreateEventCommand.Result>
    {
        private readonly IMapper _mapper;
        private readonly ICfsApiContext _db;
        private readonly IBusinessRuleSet<CreateEventRuleModel> _ruleSets;

        public CreateEventCommandhandler(ICfsApiContext db, IBusinessRuleSet<CreateEventRuleModel> ruleSets, IMapper mapper)
        {
            _db = db;
            _ruleSets = ruleSets;
            _mapper = mapper;
        }

        public async Task<CreateEventCommand.Result> Execute(CreateEventCommand command)
        {
            var ruleViolations = new List<BusinessRuleResult>() { };
            CreateEventRuleModel ruleModel = _mapper.Map<CreateEventRuleModel>(command);
            User currentUser = _db.Users.FirstOrDefault(user => user.UserName.Equals(command.UserName));
            Responder responder = _db.Responders.FirstOrDefault(res => res.Name.Equals(command.Responder));            
            EventType eventType = _db.EventTypes.FirstOrDefault(item => item.Name.Equals(command.EventTypeCode));            
            ruleModel.UserId = currentUser?.Id;
            ruleModel.ResponderId = responder?.Id;
            ruleModel.EventTypeId = eventType?.Id;
            ruleModel.IsSameAgency = currentUser?.AgencyId == responder.AgencyId;

            ruleViolations.AddRange(_ruleSets.ExecuteRules(ruleModel).Where(x => x.IsFailed));

            if (ruleViolations.Count > 0)
            {
                var message = ruleViolations
                    .SelectMany(x => x.BusinessRuleResults)
                    .Select(x => x.ErrorMessage)
                    .ConvertExceptionMessage();

                throw new Exception(message);
            }
            CfsEvent cfsEvent = _mapper.Map<CfsEvent>(command);
            cfsEvent.UserId = currentUser.Id;
            cfsEvent.ResponderId = responder.Id;
            cfsEvent.EventTypeId = eventType.Id;

            _db.Events.Add(cfsEvent);
            await _db.SaveChangesAsync();
            CreateEventResponse response = _mapper.Map<CreateEventResponse>(cfsEvent);
            response.AgencyId = currentUser.AgencyId;
            response.EventId = cfsEvent.Id;
            response.Responder = responder.Name;
            return new CreateEventCommand.Result
            {
                Data = response
            };
        }
    }
}
