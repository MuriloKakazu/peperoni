using System;
using System.Configuration;

namespace Data.Repository {
    public class ConnectionStringRepository {
        private static ConnectionStringSettingsCollection ConnectionStrings => ConfigurationManager.ConnectionStrings;

        public string GetConnectionString(string context) {
            try {

                var contextConfig = ConfigurationManager.ConnectionStrings[context];
                EnsureConfigExists(contextConfig, $"Config not set for context: {context}");
                return contextConfig.ConnectionString;
                
            } catch (Exception e) {
                throw new ConnectionStringRepositoryException($"Unexpected error for context '{context}': {e.Message}");
            }
        }

        private void EnsureConfigExists(ConfigurationElement config, string message) {
            if (config == null) {
                throw new ConnectionStringRepositoryException(message);
            }
        }

        public class ConnectionStringRepositoryException : Exception {
            public ConnectionStringRepositoryException(string message) 
                : base(message) { }
        }
    }
}
