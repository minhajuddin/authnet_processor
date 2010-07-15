using NUnit.Framework;

namespace Tests.Unit.Parsers {
    [TestFixture]
    public class CreateCustomerShippingParserTests {
        [Test]
        public void CanParse() {

            var rawXml = @"<?xml version='1.0' encoding='utf-8'?>
<createCustomerShippingAddressResponse xmlns='AnetApi/xml/v1/schema/AnetApiSchema.xsd'>
  <messages>
    <resultCode>Ok</resultCode>
    <message>
      <code>I00001</code>
      <text>Successful.</text>
    </message>
  </messages>
  <customerAddressId>30000</customerAddressId>
</createCustomerShippingAddressResponse>";

            var parser = new CreateCustomerShippingParser();

            var response = parser.Parse(rawXml);

            Assert.AreEqual(true, response.Success);
            Assert.AreEqual("Successful.", response.Message);
            Assert.AreEqual("30000", response.ParameterSet["customerAddressId"].ToString());
        }
    }
}