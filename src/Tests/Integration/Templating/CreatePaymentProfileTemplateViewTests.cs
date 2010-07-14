using System;
using NUnit.Framework;
using Tests.Integration.Gateways;

namespace Tests.Integration.Templating {
    [TestFixture]
    public class CreatePaymentProfileTemplateViewTests {
        [Test]
        public void RenderCreatePaymentProfileTemplate() {

            var customer = new Customer
                               {
                                   Description = "test profile one",
                                   Email = "test@cosmicvent.com",
                                   FirstName = "Rafi",
                                   LastName = "Sk",
                                   Address = "Rajendranagar",
                                   City = "Hyderabad",
                                   State = "AP",
                                   Zip = "500048",
                                   Company = "cosmicvent",
                                   Country = "India",
                                   CardNumber = "4111111111111111",
                                   ExpirationDate = new DateTime(2010, 07, 14).ToString("yyyy-MM")

                               };
            var factory = TestHelper.TemplateFactory;
            var template = factory.GetInstance("createCustomerPaymentProfileRequest.spark");
            template.Authentication = ObjectMother.TestAuthentication;
            var result = template.Render(customer);

            Assert.AreEqual(@"<?xml version='1.0' encoding='utf-8' ?>
<createCustomerPaymentProfileRequest xmlns='AnetApi/xml/v1/schema/AnetApiSchema.xsd'>  <merchantAuthentication>
    <name>54PB5egZ</name>
    <transactionKey>48V258vr55AE8tcg</transactionKey>
  </merchantAuthentication>
  <customerProfileId></customerProfileId>
  <paymentProfile>
    <billTo>
      <firstName>Rafi</firstName>
      <lastName>Sk</lastName>
      <company>cosmicvent</company>
      <address>Rajendranagar</address>
      <city>Hyderabad</city>
      <state>AP</state>
      <zip>500048</zip>
      <country>India</country>
      <phoneNumber></phoneNumber>
      <faxNumber></faxNumber>
    </billTo>
    <payment>
      <creditCard>
        <cardNumber>4111111111111111</cardNumber>
        <expirationDate>2010-07</expirationDate>
      </creditCard>
    </payment>
  </paymentProfile>
  <validationMode>liveMode</validationMode>
</createCustomerPaymentProfileRequest>
", result);

        }

    }
}