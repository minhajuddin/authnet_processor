using Authnet;
using NUnit.Framework;

namespace Tests.Integration.Gateways {
    [TestFixture]
    public class CustomerInformationManagerTests {
        [Test]
        public void CanGetAllCustomersIds() {
            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            var ids = cim.GetCustomerProfileIds();
            Assert.NotNull(ids);
            Assert.Greater(ids.Length, 0);
        }

        [Test]
        public void CanCreateCustomerProfile() {
            var customer = new Customer { Description = "test profile 1", Email = "test@cosmicvent.com" };
            var cim = new CustomerInformationManager(TestHelper.TemplateFactory, ObjectMother.TestAuthentication);
            var response = cim.CreateCustomerProfile(customer);
            Assert.IsTrue(response.Success);
            Assert.NotNull(response.ParameterSet["customerProfileId"]);
        }
    }

    public class Customer : ICustomer {
        public string Description { get; set; }
        public string Email { get; set; }
    }
}