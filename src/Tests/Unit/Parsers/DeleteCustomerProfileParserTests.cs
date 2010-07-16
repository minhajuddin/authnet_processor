using Authnet.Parsers;
using NUnit.Framework;

namespace Tests.Unit.Parsers {
    [TestFixture]
    public class DeleteCustomerProfileParserTests {
        [Test]
        public void CanParser() {
            var parser = new DeleteCustomerProfileParser();
            var xmlRaw = @"<?xml version=""1.0"" encoding=""utf-8""?>
<deleteCustomerProfileResponse xmlns=""AnetApi/xml/v1/schema/AnetApiSchema.xsd"">
  <messages>
    <resultCode>Ok</resultCode>
    <message>
      <code>I00001</code>
      <text>Successful.</text>
    </message>
  </messages>
</deleteCustomerProfileResponse>";

            var response = parser.Parse(xmlRaw);

            Assert.AreEqual(true, response.Success);
            Assert.AreEqual("Successful.", response.Message);
        }
    }

}