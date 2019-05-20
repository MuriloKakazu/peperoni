using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Infrastructure.Builder {
    public class CommandBuilder {
        private SqlCommand Command;

        public CommandBuilder() {
            Command = new SqlCommand();
        }

        public CommandBuilder WithConnection(SqlConnection connection) {
            Command.Connection = connection;
            return this;
        }

        public CommandBuilder WithSql(string sql) {
            Command.CommandType = CommandType.Text;
            Command.CommandText = sql;
            return this;
        }

        public CommandBuilder WithProcedure(string procedure) {
            Command.CommandType = CommandType.StoredProcedure;
            Command.CommandText = procedure;
            return this;
        }

        public CommandBuilder WithParameter(SqlParameter parameter) {
            Command.Parameters.Add(parameter);
            return this;
        }

        public CommandBuilder WithParameters(ICollection<SqlParameter> parameters) {
            Command.Parameters.AddRange(parameters.ToArray());
            return this;
        }

        public CommandBuilder WithParameters(params SqlParameter[] parameters) {
            Command.Parameters.AddRange(parameters);
            return this;
        }

        public SqlCommand Build() {
            return Command;
        }
    }
}
