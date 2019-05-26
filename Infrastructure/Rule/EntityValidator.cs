using Infrastructure.Data;
using System.Collections.Generic;

namespace Infrastructure.Rule {
    public abstract class EntityValidator<T> where T : Entity {
        protected List<T> Entities { get; set; }

        protected EntityValidator() {
            Entities = new List<T>();
        }

        public EntityValidator(ICollection<T> entities) : 
            this() {
            Entities.AddRange(entities);
        }

        public EntityValidator(T entity) : 
            this() {
            Entities.Add(entity);
        }

        public abstract EntityValidator<T> Validate();

        protected bool HasId(Entity entity) {
            return entity.HasId();
        }

        protected bool HasNoId(Entity entity) {
            return !entity.HasId();
        }
    }
}
