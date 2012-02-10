﻿using System.Collections.Generic;

namespace Shared.Domain.Infrastructure
{
    public abstract class EntityBase
    {

        private readonly List<BusinessRule> _brokenRules = new List<BusinessRule>();

        protected abstract void Validate();

        public IEnumerable<BusinessRule> GetBrokenRules()
        {
            _brokenRules.Clear();
            Validate();
            return _brokenRules;
        }

        protected void AddBrokenRule(BusinessRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }

        protected void AddBrokenRule(string rule)
        {
           AddBrokenRule(new BusinessRule(rule));
        }
    }

    public abstract class EntityBase<TID> : EntityBase
    {
        protected EntityBase(TID id)
        {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Id = id;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        public virtual TID Id { get; protected set; }

    }

}
