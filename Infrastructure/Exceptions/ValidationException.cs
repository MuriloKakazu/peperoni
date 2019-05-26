using System;

namespace Infrastructure.Exceptions {
    public class ValidationException : Exception {
        public ValidationException(string message) :
            base(message) {
        }
    }
}
