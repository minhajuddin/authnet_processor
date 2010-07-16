using Authnet.Parsers;
using NUnit.Framework;

namespace Tests.Unit.Parsers {
    [TestFixture]
    public class GetCustomerShippingAddressParserTests {

        [Test]
        public void CanParse() {
            var parser = new GetCustomerShippingAddressParser();
            var rawXml = @"<?xml version=""1.0"" encoding=""utf-8""?>
<getCustomerShippingAddressResponse xmlns=""AnetApi/xml/v1/schema/AnetApiSchema.xsd"">
  <messages>
    <resultCode>Ok</resultCode>
    <message>
      <code>I00001</code>
      <text>Successful.</text>
    </message>
  </messages>
  <address>
    <firstName>John</firstName>
    <lastName>Doe</lastName>
    <company></company>
    <address>123 Main St.</address>
    <city>Bellevue</city>
    <state>WA</state>
    <zip>98004</zip>
    <country>USA</country>
    <phoneNumber>000-000-0000</phoneNumber>
    <faxNumber></faxNumber>
    <customerAddressId>30000</customerAddressId>
  </address>
</getCustomerShippingAddressResponse>";
            var response = parser.Parse(rawXml);

            Assert.AreEqual(true, response.Success);
            Assert.AreEqual("Successful.", response.Message);
            Assert.AreEqual("30000", response.Params["customerAddressId"].ToString());
        }

    }

}