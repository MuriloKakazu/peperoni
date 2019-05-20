﻿using Infrastructure.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domain.Repository {
    public interface IRepository<T> where T : Entity {
        bool Exists(string id);
        T Get(string id);
        T Save(T entity);
        void Delete(T entity);
        ICollection<T> Get(params string[] ids);
        ICollection<T> Fetch(int limit, int offset);
        ICollection<SqlParameter> GetParameters(T entity);
    }
}
