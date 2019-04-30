using System;
using System.Collections.Specialized;
using System.Configuration;

namespace Data {
    static class DatabaseHelper {
        private static NameValueCollection DatabaseSettings => ConfigurationManager.AppSettings;

        public static string GetConnectionString() {
            var settings = DatabaseSettings;

            var database = settings["DB_NAME"];
            var username = settings["DB_USER"];
            var password = settings["DB_PASS"];
            var hostname = settings["DB_HOST"];
            var port     = settings["DB_PORT"];

            return String.Join(";",
                "Data Source=" + hostname + ',' + port,
                "Initial Catalog=" + database,
                "User ID=" + username,
                "Password=" + password
            );
        }
    }
}
