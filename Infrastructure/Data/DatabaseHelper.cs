using Infrastructure.Exceptions;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Data {
    public static class DatabaseHelper {
        public static ICollection<DataRow> QueryRows(SqlCommand command) {
            var set = new DataSet();
            var affectedRows = new SqlDataAdapter(command).Fill(set);

            var table = set.Tables[0];
            var rows = new DataRow[table.Rows.Count];
            table.Rows.CopyTo(rows, 0);

            return rows;
        }
    }
}
