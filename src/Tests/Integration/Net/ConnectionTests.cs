using Authnet.Exceptions;
using Authnet.Net;
using NUnit.Framework;

namespace Tests.Integration.Net {
    [TestFixture]
    public class ConnectionTests {

        [Test]
        public void CanMakeAValidRequestToAServer() {
            var cxn = new Connection("http://google.com");
            var response = cxn.Request("get", null, null);
        }

        [Test]
        [ExpectedException(typeof(ConnectionException))]
        public void ResponseExceptionIsThrownIfResponseIsNotSuccessful() {
            var cxn = new Connection("http://cosmicvent.com/test-tube-baby");
            var response = cxn.Request("get", null, null);
        }
    }
}