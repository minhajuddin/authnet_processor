using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Authnet.Core.Net;
using Authnet.Core.Exceptions;

namespace Tests.Net {
    [TestFixture]
    public class ConnectionTests {

        [Test]
        public void CanMakeAValidRequestToAServer() {
            var cxn = new Connection( "http://google.com" );
            //var response = cxn.Request( "get", null, new Dictionary<string, string> { { "content-type", "text/html" } } );
            var response = cxn.Request( "get", null, null );
        }

        [Test]
        [ExpectedException( typeof( ConnectionException ) )]
        public void ResponseExceptionIsThrownIfResponseIsNotSuccessful() {
            var cxn = new Connection( "http://cosmicvent.com/test-tube-baby" );
            //var response = cxn.Request( "get", null, new Dictionary<string, string> { { "content-type", "text/html" } } );
            var response = cxn.Request( "get", null, null );
            Console.WriteLine( response );
        }
    }
}
