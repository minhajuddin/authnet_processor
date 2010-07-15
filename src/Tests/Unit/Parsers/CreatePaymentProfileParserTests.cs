using Authnet.Parsers;
using NUnit.Framework;

namespace Tests.Unit.Parsers {
    [TestFixture]
    public class CreatePaymentProfileParserTests {
        [Test]
        public void CanParse() {
            var rawXml = @"<?xml version='1.0' encoding='utf-8'?>
                            <createCustomerPaymentProfileResponse xmlns='AnetApi/xml/v1/schema/AnetApiSchema.xsd'>
                                <messages>
                                    <resultCode>Ok</resultCode>
                                    <message>
                                        <code>I00001</code>
                                        <text>Successful.</text>
                                    </message>
                                </messages>
                                <customerPaymentProfileId>20000</customerPaymentProfileId>
                                <validationDirectResponse>1,1,1,This transaction has been approved.,000000,Y,2000000000,none,Test transaction for ValidateCustomerPaymentProfile.,0.01,CC,auth_only,custId123,John,Doe,,123 Main St.,Bellevue,WA,98004,USA,000-000-0000,,mark@example.com,,,,,,,,,0.00,0.00,0.00,,none,D18EB6B211FE0BBF556B271FDA6F92EE,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,</validationDirectResponse>
                            </createCustomerPaymentProfileResponse>";

            var parser = new CreateCustomerPaymentProfileParser();
            var result = parser.Parse(rawXml);

            Assert.IsTrue(result.Success);
            Assert.AreEqual("Successful.", result.Message);
            Assert.AreEqual("20000", result.Params["customerPaymentProfileId"].ToString());
            Assert.AreEqual("1,1,1,This transaction has been approved.,000000,Y,2000000000,none,Test transaction for ValidateCustomerPaymentProfile.,0.01,CC,auth_only,custId123,John,Doe,,123 Main St.,Bellevue,WA,98004,USA,000-000-0000,,mark@example.com,,,,,,,,,0.00,0.00,0.00,,none,D18EB6B211FE0BBF556B271FDA6F92EE,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,", result.Params["validationDirectResponse"].ToString());

        }
    }
}