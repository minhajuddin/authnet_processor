using NUnit.Framework;

namespace Tests.Integration.Templating {
    [TestFixture]
    public class UpdateCustomerProfileTemplateViewTests {
        [Test]
        public void RenderUpdateCustomerProfileTemplateView() {

            var customer = ObjectMother.GetMockProfileAttributes(x =>
            {
                x.CustomerId = "test profile";
                x.Email = "test2@cosmicvent.com";
                x.GateWayId = "8712378";
            });
            var factory = TestHelper.TemplateFactory;
            var template = factory.GetInstance("updateCustomerProfileRequest.spark");
            template.Authentication = ObjectMother.TestAuthentication;
            var result = template.Render(customer);

            var expectedXml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<updateCustomerProfileRequest xmlns=""AnetApi/xml/v1/schema/AnetApiSchema.xsd"">  <merchantAuthentication>
    <name>54PB5egZ</name>
    <transactionKey>48V258vr55AE8tcg</transactionKey>
  </merchantAuthentication>
  <profile>
    <merchantCustomerId>test2@cosmicvent.com</merchantCustomerId>
    <description>test profile</description>
    <email>test2@cosmicvent.com</email>
    <customerProfileId>8712378</customerProfileId>
  </profile>
</updateCustomerProfileRequest>";
            Assert.AreEqual(expectedXml, result);

        }

    }
}