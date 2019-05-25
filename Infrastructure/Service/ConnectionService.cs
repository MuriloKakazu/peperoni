using Infrastructure.Encryption;
using Infrastructure.Repository;
using System;

namespace Infrastructure.Service {
    public class ConnectionService {
       private AesRepository AesRepository { get; set; }
       private ConnectionStringRepository ConnectionStringRepository { get; set; }

        public ConnectionService() {
            AesRepository = new AesRepository();
            ConnectionStringRepository = new ConnectionStringRepository();
        }

        public string GetConnectionStringForContext(string context) {
            try {

                var aes = AesRepository.GetAes(context);
                var encrypted = ConnectionStringRepository.GetConnectionString(context);
                var decrypted = Decrypt.Base64(encrypted).WithAes(aes);

                return decrypted;

            } catch (AesRepository.AesRepositoryException e) {
                throw new ConnectionServiceException($"Error retrieving aes: {e.Message}");
            } catch (ConnectionStringRepository.ConnectionStringRepositoryException e) {
                throw new ConnectionServiceException($"Error retrieving connection string: {e.Message}");
            } catch (Exception e) {
                throw new ConnectionServiceException(
                    $"Unknown error when attempting to retrieve connection " +
                    $"string for context '{context}': {e.Message}");
            }
        }

        public class ConnectionServiceException : Exception {
            public ConnectionServiceException(string message) 
                : base(message) { }
        }
    }
}
