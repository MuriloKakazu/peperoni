using Infrastructure.Encryption;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Infrastructure.Repository {
    public class AesRepository {
        private static string ApplicationPath => AppDomain.CurrentDomain.BaseDirectory;

        public Aes GetAes(string resourceKey) {
            return GetAesFromFile(new Uri($"{ApplicationPath}/aes/{resourceKey}.aes"));
        }

        public Aes GetAesFromFile(Uri resource) {
            try {

                var fileContent = File.ReadAllText(resource.AbsolutePath);
                return JsonConvert.DeserializeObject<Aes>(fileContent);

            } catch (DirectoryNotFoundException) {
                throw new AesRepositoryException($"Aes directory not found");
            } catch (FileNotFoundException) {
                throw new AesRepositoryException($"Aes file not found: {resource}");
            } catch (Exception e) {
                throw new AesRepositoryException($"Unexpected error: {e.Message}");
            }
        }

        public class AesRepositoryException : Exception {
            public AesRepositoryException(string message)
                : base(message) { }
        }
    }
}
