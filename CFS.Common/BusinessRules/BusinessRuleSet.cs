using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CFS.Common.BusinessRules
{
    public class BusinessRuleSet<T> : IBusinessRuleSet<T>
    {
        private IServiceProvider provider { get; set; }
        private IList<IBusinessRule<T>> _rules = new List<IBusinessRule<T>>();

        public IList<IBusinessRule<T>> Rules
        {
            get
            {
                if (_rules.Count > 0) return _rules;

                var assemblies = Assembly
                            .GetEntryAssembly()
                            .GetReferencedAssemblies()
                            .Select(Assembly.Load)
                            .SelectMany(s => s.GetTypes())
                            .Where(p => typeof(IBusinessRule<T>).IsAssignableFrom(p));


                foreach (var a in assemblies)
                {
                    _rules.Add((IBusinessRule<T>)provider.GetService(a));
                }
                return _rules;
            }
        }


        public BusinessRuleSet(IServiceProvider provider) { this.provider = provider; }

        public IEnumerable<BusinessRuleResult> ExecuteRules(T instance)
        {
            return Rules.Select(rule =>
            {
                var result = rule.Execute(instance);

                return result;
            }).ToList();
        }
    }
}
