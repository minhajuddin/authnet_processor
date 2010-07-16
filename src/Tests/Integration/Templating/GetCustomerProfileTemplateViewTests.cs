using NUnit.Framework;

namespace Tests.Integration.Templating {
    [TestFixture]
    public class GetCustomerProfileTemplateViewTests {
        [Test]
        public void RenderGetCustomerProfileTemplateView() {

            var profileId = ObjectMother.GetMockProfileAttributes(x =>
            {
                x.GateWayId = "12412";
            });

            var factory = TestHelper.TemplateFactory;
            var template = factory.GetInstance("getCustomerProfileRequest.spark");
            template.Authentication = ObjectMother.TestAuthentication;
            var result = template.Render(profileId);

            var expectedXml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<getCustomerProfileRequest xmlns=""AnetApi/xml/v1/schema/AnetApiSchema.xsd"">  <merchantAuthentication>
    <name>54PB5egZ</name>
    <transactionKey>48V258vr55AE8tcg</transactionKey>
  </merchantAuthentication>
  <customerProfileId>12412</customerProfileId>
</getCustomerProfileRequest>";

            Assert.AreEqual(expectedXml, result);

        }

    }
}