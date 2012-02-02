using System.Collections.Generic;

namespace Shared.Domain.Infrastructure
{
    // ReSharper disable UnusedMember.Global
    public abstract class EntityBase<TId>
    // ReSharper restore UnusedMember.Global
    {
        private readonly List<BusinessRule> _brokenRules = new List<BusinessRule>();

        // ReSharper disable MemberCanBePrivate.Global
        // ReSharper disable UnusedAutoPropertyAccessor.Global
        public TId Id { get; set; }
        // ReSharper restore UnusedAutoPropertyAccessor.Global
        // ReSharper restore MemberCanBePrivate.Global

        protected abstract void Validate();

        // ReSharper disable UnusedMember.Global
        public IEnumerable<BusinessRule> GetBrokenRules()
        // ReSharper restore UnusedMember.Global
        {
            _brokenRules.Clear();
            Validate();
            return _brokenRules;
        }

        // ReSharper disable UnusedMember.Global
        protected void AddBrokenRule(BusinessRule businessRule)
        // ReSharper restore UnusedMember.Global
        {
            _brokenRules.Add(businessRule);
        }

        public override bool Equals(object entity)
        {
            return entity != null
               && entity is EntityBase<TId>
               && this == (EntityBase<TId>)entity;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(EntityBase<TId> entity1,
           EntityBase<TId> entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
            {
                return true;
            }

            if ((object)entity1 == null || (object)entity2 == null)
            {
                return false;
            }

            if (entity1.Id.ToString() == entity2.Id.ToString())
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(EntityBase<TId> entity1,
            EntityBase<TId> entity2)
        {
            return (!(entity1 == entity2));
        }
    }

}
