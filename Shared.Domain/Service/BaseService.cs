using Shared.Domain.Logic;
using Shared.Domain.Repository;

namespace Shared.Domain.Service
{
    public class BaseService<T> : IDomainService<T>
        where T : EntityBase, IAggregateRoot
    {
        protected readonly IEntityRepository<T> EntityRepository;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IEntityValidator EntityValidator;
        private readonly IEntityMutator<T> _mutator;

        protected BaseService(IEntityRepository<T> entityRepository, IUnitOfWork unitOfWork, IEntityValidator entityValidator, IEntityMutator<T> mutator )
        {
            EntityRepository = entityRepository;
            UnitOfWork = unitOfWork;
            EntityValidator = entityValidator;
            _mutator = mutator;
        }

        public virtual void Save(T entity)
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