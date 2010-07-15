using Authnet.Parsers;
using NUnit.Framework;

namespace Tests.Unit.Parsers {
    [TestFixture]
    public class CreateCustomerProfileTransactionParserTests {
        [Test]

        public void CanParse() {

            var parser = new CreateCustomerProfileTransactionParser();

            var rawXml = @"<?xml version='1.0' encoding='utf-8'?>
<createCustomerProfileTransactionResponse xmlns='AnetApi/xml/v1/schema/AnetApiSchema.xsd'>
  <messages>
    <resultCode>Ok</resultCode>
    <message>
      <code>I00001</code>
      <text>Successful.</text>
    </message>
  </messages>
  <directResponse>1,1,1,This transaction has been approved.,000000,Y,2000000001,INV000001,description of transaction,10.95,CC,auth_capture,custId123,John,Doe,,123 Main St.,Bellevue,WA,98004,USA,000-000-0000,,mark@example.com,John,Doe,,123 Main St.,Bellevue,WA,98004,USA,1.00,0.00,2.00,FALSE,PONUM000001,D18EB6B211FE0BBF556B271FDA6F92EE,M,2,,,,,,,,,,,,,,,,,,,,,,,,,,,,</directResponse>
</createCustomerProfileTransactionResponse>";

            var response = parser.Parse(rawXml);

            Assert.AreEqual(true, response.Success);
            Assert.AreEqual("Successful.", response.Message);
            Assert.IsNotNullOrEmpty(response.Params["directResponse"].ToString());

        }
    }
}