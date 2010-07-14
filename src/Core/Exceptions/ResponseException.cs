using System;

namespace Authnet.Exceptions {
    public class ResponseException : Exception {
        public ResponseException(string message)
            : base(message) {
        }
    }
}