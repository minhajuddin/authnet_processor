using Authnet.Parsers;
using NUnit.Framework;

namespace Tests.Unit.Parsers {
    [TestFixture]
    public class UpdateCustomerProfileParserTests {
        [Test]
        public void CanParse() {
            var updateCustomerProfileParser = new UpdateCustomerProfileParser();

            var rawXml = @"<?xml version=""1.0"" encoding=""utf-8""?>
<updateCustomerProfileResponse xmlns=""AnetApi/xml/v1/schema/AnetApiSchema.xsd"">
  <messages>
    <resultCode>Ok</resultCode>
    <message>
      <code>I00001</code>
      <text>Successful.</text>
    </message>
  </messages>
</updateCustomerProfileResponse>";

            var response = updateCustomerProfileParser.Parse(rawXml);
            Assert.AreEqual(true, response.Success);
            Assert.AreEqual("Successful.", response.Message);

        }

    }
}