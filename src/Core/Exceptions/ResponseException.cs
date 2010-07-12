using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Authnet.Exceptions {
    public class ResponseException : Exception {
        public ResponseException(string message)
            : base(message) {
        }
    }
}