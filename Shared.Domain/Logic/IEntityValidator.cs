namespace Shared.Domain.Logic
{
    public interface IEntityValidator
    {
        bool Validate(RulesEntityBase rulesEntity);
    }
}