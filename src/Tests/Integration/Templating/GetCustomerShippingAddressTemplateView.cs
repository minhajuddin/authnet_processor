using System;
using System.Collections.Generic;
using Authnet;
using NUnit.Framework;

namespace Tests.Integration.Templating {
    [TestFixture]
    public class GetCustomerShippingAddressTemplateView {

        private IProfileAttributes _profileAttributes;
        private IAddressAttributes _addressAttributes;

        private Dictionary<string, object> _getShippingAddressDictionary;

        [SetUp]
        public void Setup() {

            _profileAttributes = ObjectMother.GetMockProfileAttributes(x =>
            {
                x.GateWayId = "78234";
            });

            _addressAttributes = ObjectMother.GetMockIAddressAttributes(x =>
            {
                x.GateWayId = "83223";
            });

            _getShippingAddressDictionary = new Dictionary<string, object>();
            _getShippingAddressDictionary.Add("profileAttributes", _profileAttributes);
            _getShippingAddressDictionary.Add("addressAttributes", _addressAttributes);

        }

        [Test]
        public void RenderCreatePaymentProfileTemplate() {


            var factory = TestHelper.TemplateFactory;
            var template = factory.GetInstance("getCustomerShippingAddressRequest.spark");
            template.Authentication = ObjectMother.TestAuthentication;
            var result = template.Render(_getShippingAddressDictionary);

            var expectedXml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<getCustomerShippingAddressRequest xmlns=""AnetApi/xml/v1/schema/AnetApiSchema.xsd"">  <merchantAuthentication>
    <name>54PB5egZ</name>
    <transactionKey>48V258vr55AE8tcg</transactionKey>
  </merchantAuthentication>
  <customerProfileId>78234</customerProfileId>
  <customerAddressId>83223</customerAddressId>
</getCustomerShippingAddressRequest>";

            Assert.AreEqual(expectedXml, result);

        }

    }
}