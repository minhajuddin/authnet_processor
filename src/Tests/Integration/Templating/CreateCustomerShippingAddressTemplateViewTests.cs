using NUnit.Framework;

namespace Tests.Integration.Templating {
    [TestFixture]
    public class CreateCustomerShippingAddressTemplateViewTests {
        [Test]
        public void RenderCreateCustomerShippingAddressTemplateView() {

            var customerAddress = ObjectMother.GetMockCustomerAddress(x =>
            {
                x.FirstName = "Rafi";
                x.LastName = "Sk";
                x.Address = "Rajendranagar";
                x.City = "Hyderabad";
                x.State = "AP";
                x.Zip = "500048";
                x.Company = "cosmicvent";
                x.Country = "India";
                x.PhoneNumber = "9951313930";
            });
            var factory = TestHelper.TemplateFactory;
            var template = factory.GetInstance("createCustomerShippingAddressRequest.spark");
            template.Authentication = ObjectMother.TestAuthentication;
            var result = template.Render(customerAddress);

            var expectedXml =
                @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<createCustomerShippingAddressRequest xmlns=""AnetApi/xml/v1/schema/AnetApiSchema.xsd"">  <merchantAuthentication>
    <name>54PB5egZ</name>
    <transactionKey>48V258vr55AE8tcg</transactionKey>
  </merchantAuthentication>
  <customerProfileId></customerProfileId>
  <address>
    <firstName>Rafi</firstName>
    <lastName>Sk</lastName>
    <company>cosmicvent</company>
    <address>Rajendranagar</address>
    <city>Hyderabad</city>
    <state>AP</state>
    <zip>500048</zip>
    <country>India</country>
    <phoneNumber>9951313930</phoneNumber>
    <faxNumber></faxNumber>
  </address>
</createCustomerShippingAddressRequest>
";

            Assert.AreEqual(expectedXml, result);
        }

    }
}