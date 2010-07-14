using NUnit.Framework;

namespace Tests.Integration.Templating {
    [TestFixture]
    public class CreateCustomerProfileTemplateViewTests {
        [Test]
        public void Render_RenderCreateCustomerProfileTemplateView_ProvidedCustomer() {
            var customer = ObjectMother.GetMockCustomer(x =>
                                                            {
                                                                x.Description = "test profile";
                                                                x.Email = "test2@cosmicvent.com";
                                                            });
            var factory = TestHelper.TemplateFactory;
            var template = factory.GetInstance("createCustomerProfileRequest.spark");
            template.Authentication = ObjectMother.TestAuthentication;
            var result = template.Render(customer);

            var expectedXml =
                @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<createCustomerProfileRequest xmlns=""AnetApi/xml/v1/schema/AnetApiSchema.xsd"">  <merchantAuthentication>
    <name>54PB5egZ</name>
    <transactionKey>48V258vr55AE8tcg</transactionKey>
  </merchantAuthentication>
  <profile>
    <merchantCustomerId>test2@cosmicvent.com</merchantCustomerId>
    <description>test profile</description>
    <email>test2@cosmicvent.com</email>
  </profile>
</createCustomerProfileRequest>";
            Assert.AreEqual(expectedXml, result);

        }
    }
}