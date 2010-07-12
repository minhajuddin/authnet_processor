using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Authnet.Exceptions {
    public class ConnectionException : Exception {
        public ConnectionException(string message, Exception exception)
            : base(message, exception) {
        }
        public ConnectionException(string message)
            : base(message) {
        }
    }
}