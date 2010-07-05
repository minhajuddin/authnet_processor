using System;
namespace Authnet {
    internal static class Logger {
        static ILogger _logger = new ConsoleLogger();

        public static void Set( ILogger logger ) {
            _logger = logger;
        }

        public static void Info( string message ) {
            _logger.Info( message );
        }
        public static void Debug( string message ) {
            _logger.Debug( message );
        }
        public static void Error( string message, Exception exception ) {
            _logger.Error( message, exception );
        }
    }
}
