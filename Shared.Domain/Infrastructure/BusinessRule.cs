namespace Shared.Domain.Infrastructure
{
    public abstract class BusinessRule
    {
        // ReSharper disable PublicConstructorInAbstractClass
        public BusinessRule(string property, string rule)
        // ReSharper restore PublicConstructorInAbstractClass
        {
            Property = property;
            Rule = rule;
        }

        // ReSharper disable UnusedAutoPropertyAccessor.Local
        private string Property { get; set; }
        // ReSharper restore UnusedAutoPropertyAccessor.Local

        // ReSharper disable MemberCanBePrivate.Global
        public string Rule { get; set; }
        // ReSharper restore MemberCanBePrivate.Global
    }
}