﻿using Infrastructure.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Infrastructure.Builder {
    public class ParameterBuilder<T> {
        private SqlParameter Parameter;

        public ParameterBuilder() {
            Parameter = new SqlParameter();
        }

        public ParameterBuilder<T> WithDirection(ParameterDirection direction) {
            Parameter.Direction = direction;
            return this;
        }

        public ParameterBuilder<T> WithType(DbType type) {
            Parameter.DbType = type;
            return this;
        }

        public ParameterBuilder<T> WithName(string name) {
            Parameter.ParameterName = name;
            return this;
        }

        public ParameterBuilder<T> WithValue(T value) {
            Parameter.Value = value;
            return this;
        }

        public SqlParameter Build() {
            return Parameter;
        }
    }
}
