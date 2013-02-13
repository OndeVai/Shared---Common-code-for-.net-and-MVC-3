#region

using Shared.Domain.Logic;
using Shared.Domain.Repository;

#endregion

namespace Shared.Domain.Service
{
    public class BaseService<T> : IDomainService<T>
        where T : EntityBase, IAggregateRoot
    {
        protected readonly IEntityRepository<T> EntityRepository;
        protected readonly IEntityValidator EntityValidator;
        protected readonly IUnitOfWork UnitOfWork;
        private readonly IEntityMutator<T> _mutator;

        protected BaseService(IEntityRepository<T> entityRepository, IUnitOfWork unitOfWork,
                              IEntityValidator entityValidator, IEntityMutator<T> mutator)
        {
            EntityRepository = entityRepository;
            UnitOfWork = unitOfWork;
            EntityValidator = entityValidator;
            _mutator = mutator;
        }

        public virtual void ValidateAndSave(T entity)
        {
            if (EntityValidator.Validate(entity))
            {
                _mutator.Mutate(entity);
                EntityRepository.Save(entity);
                UnitOfWork.Commit();
            }
        }
    }
}