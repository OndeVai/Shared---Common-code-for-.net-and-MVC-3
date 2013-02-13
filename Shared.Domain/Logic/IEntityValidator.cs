namespace Shared.Domain.Logic
{
    public interface IEntityValidator
    {
        bool Validate(EntityBase entity);
    }
}