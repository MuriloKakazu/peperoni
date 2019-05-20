using Infrastructure.Data;
using Infrastructure.Exceptions;
using System;

namespace Domain.Repository.Strategies {
    public abstract class AbstractInsertStrategy<T> : ISaveStrategy<T> where T : Entity {
        protected IRepository<T> Repository { get; set; }

        public AbstractInsertStrategy(IRepository<T> repository) {
            Repository = repository;
        }

        public virtual T Save(T entity) {
            EnsureIdNotProvided(entity);
            entity.Id = Guid.NewGuid().ToString();
            return default(T);
        }

        private void EnsureIdNotProvided(T entity) {
            if (!String.IsNullOrWhiteSpace(entity.Id)) {
                throw new DataIntegrityException("Id can not be provided before insert call");
            }
        }
    }
}
