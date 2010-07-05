using System;
namespace Authnet {
    internal class ConsoleLogger : ILogger {

        public void Info( string message ) {
            Console.WriteLine( "INFO: {0} ==> {1}", DateTime.Now, message );
        }

        public void Debug( string message ) {
            Console.WriteLine( "DEBUG: {0} ==> {1}", DateTime.Now, message );
        }

        public void Error( string message, System.Exception exception ) {
            Console.WriteLine( "ERROR: {0} ==> {1} \nEXCEPTION:\n{2}", DateTime.Now, message, exception );
        }

    }
}
