using Authnet.Parsers;
using NUnit.Framework;

namespace Tests.Unit.Parsers {
    [TestFixture]
    public class DeleteCustomerPaymentProfileParserTests {
        [Test]
        public void CanParse() {
            var parser = new DeleteCustomerPaymentProfileParser();
            var xmlRaw = @"<?xml version=""1.0"" encoding=""utf-8""?>
<deleteCustomerPaymentProfileResponse xmlns=""AnetApi/xml/v1/schema/AnetApiSchema.xsd"">
  <messages>
    <resultCode>Ok</resultCode>
    <message>
      <code>I00001</code>
      <text>Successful.</text>
    </message>
  </messages>
</deleteCustomerPaymentProfileResponse>";

            var response = parser.Parse(xmlRaw);

            Assert.AreEqual(true, response.Success);
            Assert.AreEqual("Successful.", response.Message);
        }
    }
}