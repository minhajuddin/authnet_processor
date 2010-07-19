using System;
using System.Collections.Generic;
using Authnet;
using NUnit.Framework;

namespace Tests.Integration.Templating {
    [TestFixture]
    public class UpdateCustomerPaymentProfileTemplateViewTests {
        private IProfileAttributes _profileAttributes;
        private IAddressAttributes _addressAttributes;
        private ICreditCardAttributes _creditCardAttributes;
        private IPaymentProfileAttributes _paymentProfileAttributes;
        private Dictionary<string, object> _updatePaymentProfileDictionary;

        [SetUp]
        public void Setup() {

            var random = new Random();
            _profileAttributes = ObjectMother.GetMockProfileAttributes(x =>
            {
                x.CustomerId = random.Next().ToString();
                x.Email = "test2@cosmicvent.com";
                x.GateWayId = "222222";
            });

            _addressAttributes = ObjectMother.GetMockAddressAttributes(x =>
            {
                x.FirstName = "Rafi";
                x.LastName = "Sk";
                x.Address = "Rajendranagar";
                x.City = "Hyderabad";
                x.State = "AP";
                x.Zip = "500048";
                x.Company = "cosmicvent";
                x.Country = "India";
            });
            _creditCardAttributes = ObjectMother.GetMockCreditCardAttributes(x =>
            {
                x.CardNumber = "4111111111111111";
                x.ExpirationDate = DateTime.Now.AddMonths(1).ToString("yyyy-MM");
            });

            _paymentProfileAttributes = ObjectMother.GetMockPaymentProfileAttributes(x => { x.GateWayId = "33333"; });

            _updatePaymentProfileDictionary = new Dictionary<string, object>();
            _updatePaymentProfileDictionary.Add("paymentProfileAttributes", _paymentProfileAttributes);
            _updatePaymentProfileDictionary.Add("profileAttributes", _profileAttributes);
            _updatePaymentProfileDictionary.Add("billingAddressAttributes", _addressAttributes);
            _updatePaymentProfileDictionary.Add("creditCardAttributes", _creditCardAttributes);

        }


        [Test]
        public void RenderUpdateCustomerPaymentProfileTemplateView() {
            var factory = TestHelper.TemplateFactory;
            var template = factory.GetInstance("updateCustomerPaymentProfileRequest.spark");
            template.Authentication = ObjectMother.TestAuthentication;
            var result = template.Render(_updatePaymentProfileDictionary);

            var expectedXml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<updateCustomerPaymentProfileRequest xmlns=""AnetApi/xml/v1/schema/AnetApiSchema.xsd"">  <merchantAuthentication>
    <name>54PB5egZ</name>
    <transactionKey>48V258vr55AE8tcg</transactionKey>
  </merchantAuthentication>
  <customerProfileId>222222</customerProfileId>
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
        <expirationDate>2010-08</expirationDate>
      </creditCard>
    </payment>
    <customerPaymentProfileId>33333</customerPaymentProfileId>
  </paymentProfile>
  <validationMode>liveMode</validationMode>
</updateCustomerPaymentProfileRequestt>
";
            Assert.AreEqual(expectedXml, result);

        }
    }
}