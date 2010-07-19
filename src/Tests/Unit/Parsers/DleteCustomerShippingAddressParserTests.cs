using Authnet.Parsers;
using NUnit.Framework;

namespace Tests.Unit.Parsers {
    [TestFixture]
    public class DleteCustomerShippingAddressParserTests {
        [Test]
        public void CanParse() {
            var parser = new DleteCustomerShippingAddressParser();

            var rawXml = @"<?xml version=""1.0"" encoding=""utf-8""?>
<deleteCustomerShippingAddressResponse xmlns=""AnetApi/xml/v1/schema/AnetApiSchema.xsd"">
  <messages>
    <resultCode>Ok</resultCode>
    <message>
      <code>I00001</code>
      <text>Successful.</text>
    </message>
  </messages>
</deleteCustomerShippingAddressResponse>";

            var response = parser.Parse(rawXml);
            Assert.AreEqual(true, response.Success);
            Assert.AreEqual("Successful.", response.Message);


        }
    }

}