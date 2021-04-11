namespace CFS.Common.BusinessRules
{
    public interface IBusinessRule<T>
    {
        BusinessRuleResult Result { get; }
        BusinessRuleResult Execute(T instance);
    }
}
