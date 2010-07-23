using Authnet.Parsers;
using NUnit.Framework;

namespace Tests.Unit.Parsers {
    [TestFixture]
    public class CreateCustomerProfileParserTests {
        private CreateCustomerProfileParser parser;
        [SetUp]
        public void setup() {
            parser = new CreateCustomerProfileParser();
        }

        [Test]
        public void CanParserSuccessResponse() {


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
            Assert.AreEqual("I00001", response.Code);
            Assert.AreEqual("10000", response.Params["customerProfileId"].ToString());
        }

        [Test]
        public void CanParseUnSuccessResponse() {

            var rawXml = @"<?xml version=""1.0"" encoding=""utf-8""?>
<createCustomerProfileResponse xmlns=""AnetApi/xml/v1/schema/AnetApiSchema.xsd"">
  <messages>
    <resultCode>Error</resultCode>
    <message>
      <code>E00044</code>
      <text>Customer Information Manager is not enabled.</text>
    </message>
  </messages>
</createCustomerProfileResponse>";

            var response = parser.Parse(rawXml);

            Assert.IsFalse(response.Success);
            Assert.AreEqual("Customer Information Manager is not enabled.", response.Message);
            Assert.AreEqual("E00044", response.Code);
            Assert.AreEqual("NO VALUE",response.Params.ToString());

        }
    }
}