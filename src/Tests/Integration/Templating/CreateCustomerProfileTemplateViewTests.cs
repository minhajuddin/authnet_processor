using NUnit.Framework;
using Tests.Gateways;

namespace Tests.Integration.Templating {
    [TestFixture]
    public class CreateCustomerProfileTemplateViewTests {
        [Test]
        public void Render_RenderCreateCustomerProfileTemplateView_ProvidedCustomer() {
            var customer = new Customer { Description = "test profile one", Email = "test@cosmicvent.com" };
            var factory = TestHelper.TemplateFactory;
            var template = factory.GetInstance("createCustomerProfileRequest.spark");
            template.Authentication = ObjectMother.TestAuthentication;
            var result = template.Render(customer);

            Assert.AreEqual(@"
<?xml version='1.0' encoding='utf-8'?>
<createCustomerProfileRequest xmlns='AnetApi/xml/v1/schema/AnetApiSchema.xsd'>
  <merchantAuthentication>
    <name>YourUserLogin</name>
    <transactionKey>YourTranKey</transactionKey>
  </merchantAuthentication>
  <profile>
    <merchantCustomerId>test@cosmicvent.com</merchantCustomerId>
    <description>test profile one</description>
    <email>test@cosmicvent.com</email>
  </profile>
</createCustomerProfileRequest>", result);

        }
    }
}