using System.Collections.Generic;
using Authnet;
using NUnit.Framework;

namespace Tests.Integration.Templating {
    [TestFixture]
    public class GetCustomerPaymentProfileTemplateView {
        private Dictionary<string, object> _getPaymentProfileAttributes;
        private IProfileAttributes _profileAttributes;
        private IPaymentProfileAttributes _paymentProfileAttributes;

        [SetUp]
        public void setup() {

            _profileAttributes = ObjectMother.GetMockProfileAttributes(x =>
            {
                x.GateWayId = "123215";
            });

            _paymentProfileAttributes = ObjectMother.GetMockPaymentProfileAttributes(x =>
            {
                x.GateWayId = "829831";
            });


            _getPaymentProfileAttributes = new Dictionary<string, object>();
            _getPaymentProfileAttributes.Add("profileAttributes", _profileAttributes);
            _getPaymentProfileAttributes.Add("paymentProfileAttributes", _paymentProfileAttributes);


        }

        [Test]
        public void RenderGetCustomerPaymentProfileTemplateView() {

            var factory = TestHelper.TemplateFactory;
            var template = factory.GetInstance("getCustomerPaymentProfileRequest.spark");
            template.Authentication = ObjectMother.TestAuthentication;
            var result = template.Render(_getPaymentProfileAttributes);

            var expectedXml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<getCustomerPaymentProfileRequest xmlns=""AnetApi/xml/v1/schema/AnetApiSchema.xsd"">  <merchantAuthentication>
    <name>54PB5egZ</name>
    <transactionKey>48V258vr55AE8tcg</transactionKey>
  </merchantAuthentication>
  <customerProfileId>123215</customerProfileId>
  <customerPaymentProfileId>829831</customerPaymentProfileId>
</getCustomerPaymentProfileRequest>";
            Assert.AreEqual(expectedXml, result);
        }
    }
}