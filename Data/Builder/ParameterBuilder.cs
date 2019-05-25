using Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Infrastructure.Builder {
    public class ParameterBuilder<T> : IBuilder<SqlParameter> {
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
            Optional.Of(value)
                .IfPresent(() => { Parameter.Value = value; })
                .IfNotPresent(() => { Parameter.Value = DBNull.Value; });
            return this;
        }

        public SqlParameter Build() {
            return Parameter;
        }
    }
}
