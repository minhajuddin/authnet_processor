using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Authnet;

namespace Tests.Unit {
    [TestFixture]
    public class ResponseTests {
        [Test]
        public void ResponseHasAParameterSet() {
            var response = new Response();
            Assert.NotNull( response.ParameterSet );
        }
    }
}
