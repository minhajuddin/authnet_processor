using System.Collections.Generic;
using Authnet;
using NUnit.Framework;

namespace Tests.Integration.Templating {
    [TestFixture]
    public class DeleteCustomerShippingAddressTemplateTests {
        private Dictionary<string, object> _Attributes;
        private IProfileAttributes _profileAttributes;
        private IAddressAttributes _addressAttributes;

        [SetUp]
        public void setup() {

            _profileAttributes = ObjectMother.GetMockProfileAttributes(x =>
            {
                x.GateWayId = "123215";
            });

            _addressAttributes = ObjectMother.GetMockAddressAttributes(x =>
            {
                x.GateWayId = "829831";
            });


            _Attributes = new Dictionary<string, object>();
            _Attributes.Add("profileAttributes", _profileAttributes);
            _Attributes.Add("shippingAddressAttributes", _addressAttributes);


        }

        [Test]
        public void RenderCustomerShippingAddressTemplate() {
            var factory = TestHelper.TemplateFactory;
            var template = factory.GetInstance("deleteCustomerShippingAddressRequest.spark");
            template.Authentication = ObjectMother.TestAuthentication;
            var result = template.Render(_Attributes);

            var expectedXml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<deleteCustomerShippingAddressRequest xmlns=""AnetApi/xml/v1/schema/AnetApiSchema.xsd"">  <merchantAuthentication>
    <name>54PB5egZ</name>
    <transactionKey>48V258vr55AE8tcg</transactionKey>
  </merchantAuthentication>
  <customerProfileId>123215</customerProfileId>
  <customerAddressId>829831</customerAddressId>
</deleteCustomerShippingAddressRequest>";
            Assert.AreEqual(expectedXml, result);

        }

    }
}