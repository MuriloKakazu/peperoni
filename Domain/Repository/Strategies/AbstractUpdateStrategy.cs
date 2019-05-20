using Infrastructure.Data;
using Infrastructure.Exceptions;
using System;

namespace Domain.Repository.Strategies {
    public abstract class AbstractUpdateStrategy<T> : ISaveStrategy<T> where T : Entity {
        protected IRepository<T> Repository { get; set; }

        public AbstractUpdateStrategy(IRepository<T> repository) {
            Repository = repository;
        }

        public virtual T Save(T entity) {
            EnsureIdProvided(entity);
            EnsureExists(entity);
            return default(T);
        }

        private void EnsureIdProvided(T entity) {
            if (String.IsNullOrWhiteSpace(entity.Id)) {
                throw new DataIntegrityException("Id must be provided before update call");
            }
        }

        private void EnsureExists(T entity) {
            if (!Repository.Exists(entity.Id)) {
                throw new DataIntegrityException($"Record of type {entity.GetType().Name} with Id {entity.Id} was not found");
            }
        }
    }
}
