using Authnet.Parsers;
using NUnit.Framework;

namespace Tests.Unit.Parsers {
    [TestFixture]
    public class CreateCustomerProfileParserTests {
        [Test]
        public void CanParser() {
            var parser = new CreateCustomerProfileParser();

            var rawXml = @"<?xml version='1.0' encoding='utf-8'?>
                           <createCustomerProfileResponse xmlns='AnetApi/xml/v1/schema/AnetApiSchema.xsd'>
                                <messages>
                                    <resultCode>Ok</resultCode>
                                    <message>
                                        <code>I00001</code>
                                        <text>Successful.</text>
                                    </message>
                                </messages>
                                <customerProfileId>10000</customerProfileId>
                                <customerPaymentProfileIdList></customerPaymentProfileIdList>
                                <customerShippingAddressIdList></customerShippingAddressIdList>
                                <validationDirectResponseList></validationDirectResponseList>
                            </createCustomerProfileResponse>";

            var response = parser.Parse(rawXml);

            Assert.AreEqual(true, response.Success);
            Assert.AreEqual("Successful.", response.Message);
            Assert.AreEqual("10000", response.Params["customerProfileId"].ToString());
        }
    }
}