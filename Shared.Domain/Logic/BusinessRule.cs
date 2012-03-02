namespace Shared.Domain.Logic
{
    public class BusinessRule
    {
        public BusinessRule(string rule)
        {
            Rule = rule;
        }

        public string Rule { get; set; }
    }
}