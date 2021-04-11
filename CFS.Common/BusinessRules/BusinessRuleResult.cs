using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CFS.Common.BusinessRules
{
    public class BusinessRuleResult
    {
        public List<ValidationResult> BusinessRuleResults { get; set; }
        public virtual bool IsFailed => BusinessRuleResults?.Count > 0;

        public BusinessRuleResult()
            : this(new List<ValidationResult>()) { }

        public BusinessRuleResult(List<ValidationResult> businessRuleResults)
        {
            BusinessRuleResults = businessRuleResults;
        }
    }
}
