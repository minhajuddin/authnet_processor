using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Authnet.Core;

namespace Tests.Gateways {
    [TestFixture]
    public class CustomerInformationManagerTests {
        [Test]
        public void CanGetAllCustomersIds() {
            var cim = new CustomerInformationManager( TestHelper.TemplateFactory, ObjectMother.TestAuthentication );
            var ids = cim.GetCustomerProfileIds();
            Assert.NotNull( ids );
            Assert.Greater( ids.Length, 0 );
        }
    }
}
