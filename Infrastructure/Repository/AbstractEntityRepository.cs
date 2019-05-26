using Infrastructure.Builder;
using Infrastructure.Data;
using Infrastructure.Repository.Strategies;
using Infrastructure.Rule;
using Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Infrastructure.Repository {
    public abstract class AbstractEntityRepository<T> : IEntityRepository<T> where T : Entity {
        protected string Entity { get; private set; }
        protected abstract ISaveStrategy<T> InsertStrategy { get; set; }
        protected abstract ISaveStrategy<T> UpdateStrategy { get; set; }

        protected abstract T Marshal(DataRow row);
        public abstract ICollection<SqlParameter> GetParameters(T entity);

        protected AbstractEntityRepository(string entity) {
            Entity = entity;
        }

        public virtual bool Exists(string id) {
            return Get(new string[] { id }).Any();
        }

        public virtual T Get(string id) {
            var idParameter = new ParameterBuilder<string>()
                .WithName("Id").WithValue(id).Build();

            return Marshal(
                Database.Query($"SELECT * FROM [{Entity}] WHERE Id = @Id", idParameter).FirstOrDefault());
        }

        public virtual ICollection<T> Get(params string[] ids) {
            var idParameter = new ParameterBuilder<string>()
                .WithName("Ids").WithValue(Flatten.Strings(ids)).Build();

            return Marshal(
                Database.Query($"SELECT * FROM [{Entity}] WHERE Id IN (@Ids)", idParameter));
        }

        public virtual ICollection<T> Fetch(int limit = 100, int offset = 0) {
            var limitParameter = new ParameterBuilder<int>()
                .WithName("Limit").WithValue(limit).Build();

            var offsetParameter = new ParameterBuilder<int>()
                .WithName("Offset").WithValue(offset).Build();

            return Marshal(
                Database.Query($"SELECT * FROM [{Entity}] ORDER BY Id LIMIT @Limit OFFSET @Offset", limitParameter, offsetParameter));
        }

        public virtual T Save(T entity) {
            return On<T>.Value(entity)
                .When(entity.HasId())
                    .Then(() => { UpdateStrategy.Save(entity); })
                .Else()
                    .Then(() => { InsertStrategy.Save(entity); })
                .Result();
        }

        public virtual void Delete(T entity) {
            var idParameter = new ParameterBuilder<string>()
                .WithName("Id").WithValue(entity.Id).Build();

            Database.Execute($"DELETE [{Entity}] WHERE Id = @Id", idParameter);
        }

        protected virtual ICollection<T> Marshal(ICollection<DataRow> rows) {
            ICollection<T> entities = new List<T>();

            foreach (var row in rows) {
                entities.Add(Marshal(row));
            }

            return entities;
        }
    }
}
