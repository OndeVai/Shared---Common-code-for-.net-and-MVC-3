#region

using Shared.Domain.Logic;
using Shared.Domain.Repository;

#endregion

namespace Shared.Domain.Service
{
    public class ValidatingDomainServiceBase<T> : IDomainService<T>
        where T : RulesEntityBase, IAggregateRoot
    {
        private readonly IEntityRepository<T> _entityRepository;
        private readonly IEntityValidator _entityValidator;
        private readonly IEntityMutator<T> _mutator;
        private readonly IUnitOfWork _unitOfWork;

        protected ValidatingDomainServiceBase(IEntityRepository<T> entityRepository, IUnitOfWork unitOfWork,
                                              IEntityValidator entityValidator, IEntityMutator<T> mutator)
        {
            _entityRepository = entityRepository;
            _unitOfWork = unitOfWork;
            _entityValidator = entityValidator;
            _mutator = mutator;
        }

        public virtual void ValidateAndSave(T entity)
        {
            if (_entityValidator.Validate(entity))
            {
                _mutator.Mutate(entity);
                _entityRepository.Save(entity);
                _unitOfWork.Commit();
            }
        }
    }
}