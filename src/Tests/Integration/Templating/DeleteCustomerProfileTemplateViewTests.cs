using NUnit.Framework;

namespace Tests.Integration.Templating {
    [TestFixture]
    public class DeleteCustomerProfileTemplateViewTests {
        [Test]
        public void RenderDeleteCustomerProfileTemplateView() {

            var profileAttributes = ObjectMother.GetMockProfileAttributes(x =>
            {
                x.GateWayId = "12412";
            });

            var factory = TestHelper.TemplateFactory;
            var template = factory.GetInstance("deleteCustomerProfileRequest.spark");
            template.Authentication = ObjectMother.TestAuthentication;
            var result = template.Render(profileAttributes);

            var expectedXml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<deleteCustomerProfileRequest xmlns=""AnetApi/xml/v1/schema/AnetApiSchema.xsd"">  <merchantAuthentication>
    <name>54PB5egZ</name>
    <transactionKey>48V258vr55AE8tcg</transactionKey>
  </merchantAuthentication>
  <customerProfileId>12412</customerProfileId>
</deleteCustomerProfileRequest>";

            Assert.AreEqual(expectedXml, result);

        }
    }
}