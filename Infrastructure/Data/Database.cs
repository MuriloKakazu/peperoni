using Infrastructure.Builder;
using Infrastructure.Service;
using Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Infrastructure.Data {
    public static class Database {
        private static SqlConnection Connection { get; set; }

        static Database() {
            CreateConnection();
        }

        private static void CreateConnection() {
            Connection = new SqlConnection() {
                ConnectionString = new ConnectionService()
                    .GetConnectionStringForContext("peperoni")
            };
        }

        private static void Connect() {
            Connection.Open();
        }

        private static void Disconnect() {
            Connection.Close();
        }

        public static int Execute(string sql) {
            return Execute(sql, new List<SqlParameter>());
        }

        public static int Execute(string sql, ICollection<SqlParameter> parameters) {
            return Execute(sql, parameters.ToArray());
        }

        public static int Execute(string sql, params SqlParameter[] parameters) {
            var command = new CommandBuilder()
                .WithConnection(Connection)
                .WithSql(sql)
                .WithParameters(parameters)
                .Build();

            return Execute(command);
        }

        public static int Execute(SqlCommand command) {
            Optional.Of(command.Connection)
                .IfNotPresent(() => {
                    command.Connection = Connection;
            });

            return RunOverConnection(() => {
                return command.ExecuteNonQuery();
            });
        }

        public static ICollection<DataRow> Query(string sql) {
            return Query(sql, new List<SqlParameter>());
        }

        public static ICollection<DataRow> Query(string sql, ICollection<SqlParameter> parameters) {
            return Query(sql, parameters.ToArray());
        }

        public static ICollection<DataRow> Query(string sql, params SqlParameter[] parameters) {
            var command = new CommandBuilder()
                .WithConnection(Connection)
                .WithParameters(parameters)
                .WithSql(sql)
                .Build();

            return Query(command);
        }

        public static ICollection<DataRow> Query(SqlCommand command) {
            Optional.Of(command.Connection)
                .IfNotPresent(() => {
                    command.Connection = Connection;
            });

            return RunOverConnection(() => {
                return DatabaseHelper.GetAllRowsFromFirstTable(command);
            });
        }

        private static T RunOverConnection<T>(Func<T> function) {
            try {
                Connect();
                return function.Invoke();
            } finally {
                Disconnect();
            }
        }
    }
}
