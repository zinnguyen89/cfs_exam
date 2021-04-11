using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CFS.Common.BusinessRules
{
    public abstract class BusinessRule<T> : IBusinessRule<T>, IDisposable
    {
        protected BusinessRuleResult _result;
        public BusinessRuleResult Result
        {
            get
            {
                if (_result == null)
                {
                    _result = new BusinessRuleResult()
                    {
                        BusinessRuleResults = new List<ValidationResult>() { }
                    };
                }
                if (_result.BusinessRuleResults == null)
                {
                    _result.BusinessRuleResults = new List<ValidationResult>() { };
                }
                return _result;
            }
        }

        public abstract BusinessRuleResult Execute(T instance);

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _result = null;
                }

                disposedValue = true;
            }
        }



        public void Dispose()
        {

            Dispose(true);
        }
    }
}
