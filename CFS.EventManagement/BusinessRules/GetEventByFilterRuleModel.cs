using CFS.Common.BusinessRules;
using System;
using System.ComponentModel.DataAnnotations;

namespace CFS.EventManagement.BusinessRules
{
    public class GetEventByFilterRule: BusinessRule<GetEventByFilterRuleModel>
    {
        public override BusinessRuleResult Execute(GetEventByFilterRuleModel instance)
        {
            if (instance == null)
            {
                return Result;
            }
            if (instance.EventTime != null && instance.DispatchTime != null && instance.EventTime > instance.DispatchTime)
            {
                Result.BusinessRuleResults.Add(new ValidationResult("The Dispatch Time should larger then Event time"));
            }

            return Result;
        }
    }

    public class GetEventByFilterRuleModel
    {
        public DateTime? EventTime { get; set; }
        public DateTime? DispatchTime { get; set; }
    }
}
