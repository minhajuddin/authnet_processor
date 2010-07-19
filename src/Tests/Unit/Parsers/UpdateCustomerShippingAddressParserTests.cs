using Authnet.Parsers;
using NUnit.Framework;

namespace Tests.Unit.Parsers {
    [TestFixture]
    public class UpdateCustomerShippingAddressParserTests {
        [Test]
        public void Parse() {
            var updateCustomerShippingAddressParser = new UpdateCustomerShippingAddressParser();

            var rawXml = @"<?xml version=""1.0"" encoding=""utf-8""?>
<updateCustomerShippingAddressResponse xmlns=""AnetApi/xml/v1/schema/AnetApiSchema.xsd"">
  <messages>
    <resultCode>Ok</resultCode>
    <message>
      <code>I00001</code>
      <text>Successful.</text>
    </message>
  </messages>
</updateCustomerShippingAddressResponse>";
            var response = updateCustomerShippingAddressParser.Parse(rawXml);
            Assert.AreEqual(true, response.Success);
            Assert.AreEqual("Successful.", response.Message);
        }
    }
}