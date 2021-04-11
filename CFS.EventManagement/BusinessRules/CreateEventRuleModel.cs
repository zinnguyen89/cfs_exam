using CFS.Common.BusinessRules;
using System;
using System.ComponentModel.DataAnnotations;

namespace CFS.EventManagement.BusinessRules
{
    public class CreateEventRule : BusinessRule<CreateEventRuleModel>
    {
        public override BusinessRuleResult Execute(CreateEventRuleModel instance)
        {
            if (instance == null)
            {
                return Result;
            }
            if (instance.UserId == null)
                Result.BusinessRuleResults.Add(new ValidationResult("Cannot find user"));

            if (instance.ResponderId == null)
                Result.BusinessRuleResults.Add(new ValidationResult("Responder is not exist"));

            if (string.IsNullOrEmpty(instance.Responder))
                Result.BusinessRuleResults.Add(new ValidationResult("Responder should not be null or empty"));

            if (string.IsNullOrEmpty(instance.EventNumber))
                Result.BusinessRuleResults.Add(new ValidationResult("EventNumber should not be null or empty"));

            if (instance.EventTypeCode == null)
                Result.BusinessRuleResults.Add(new ValidationResult("EventTypeCode should not be null or empty"));
            DateTime eDate, dDate;
            if (string.IsNullOrEmpty(instance.EventTime))
                Result.BusinessRuleResults.Add(new ValidationResult("Event Time should not be null or empty"));
            else
            {
                if (!DateTime.TryParse(instance.EventTime, out eDate))
                {
                    Result.BusinessRuleResults.Add(new ValidationResult("The event time should right with format 'yyyy-mm-dd hh:mm:ss.fff'"));
                }
            }


            if (string.IsNullOrEmpty(instance.DispatchTime))
            {
                Result.BusinessRuleResults.Add(new ValidationResult("Dispatch Time should not be null or empty"));
            }
            else
            {

                if (!DateTime.TryParse(instance.DispatchTime, out dDate))
                {
                    Result.BusinessRuleResults.Add(new ValidationResult("The dispatch time should right with format 'yyyy-mm-dd hh:mm:ss.fff'"));                    
                }

                if (DateTime.TryParse(instance.EventTime, out eDate) && DateTime.TryParse(instance.DispatchTime, out dDate)  && eDate.Date > dDate.Date)
                {
                    Result.BusinessRuleResults.Add(new ValidationResult("The Dispatch Time should larger then Event time"));
                }
            }


            if (!instance.IsSameAgency)
                Result.BusinessRuleResults.Add(new ValidationResult("Agency is not the same"));


            return Result;
        }
    }

    public class CreateEventRuleModel
    {
        public Guid? UserId { get; set; }
        public Guid? ResponderId { get; set; }
        public Guid? EventTypeId { get; set; }
        public string EventNumber { get; set; }
        public string EventTypeCode { get; set; }
        public string EventTime { get; set; }
        public string DispatchTime { get; set; }
        public string Responder { get; set; }
        public bool IsSameAgency { get; set; }
    }
}
