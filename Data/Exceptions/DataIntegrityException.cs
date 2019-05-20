using System;

namespace Infrastructure.Exceptions {
    public class DataIntegrityException : Exception {
        public DataIntegrityException(string message) : 
            base(message) {
        }
    }
}
