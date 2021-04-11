using System.Collections.Generic;

namespace CFS.Common.BusinessRules
{
    public interface IBusinessRuleSet<T>
    {
        IList<IBusinessRule<T>> Rules { get; }
        IEnumerable<BusinessRuleResult> ExecuteRules(T instance);
    }
}
