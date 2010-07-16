using Authnet.Parsers;
using NUnit.Framework;

namespace Tests.Unit.Parsers {
    [TestFixture]
    public class GetCustomerProfileParserTests {
        [Test]
        public void CanParse() {

            var parser = new GetCustomerProfileParser();

            var rawXml = @"<?xml version=""1.0"" encoding=""utf-8""?>
<getCustomerProfileResponse xmlns=""AnetApi/xml/v1/schema/AnetApiSchema.xsd"">
  <messages>
    <resultCode>Ok</resultCode>
    <message>
      <code>I00001</code>
      <text>Successful.</text>
    </message>
  </messages>
  <profile>
    <merchantCustomerId>custId123</merchantCustomerId>
    <description>some description</description>
    <email>mark@example.com</email>
    <customerProfileId>10000</customerProfileId>
</profile>
</getCustomerProfileResponse>
";

            var response = parser.Parse(rawXml);

            Assert.AreEqual(true, response.Success);
            Assert.AreEqual("Successful.", response.Message);
            Assert.AreEqual("some description", response.Params["Description"].ToString());
            Assert.AreEqual("mark@example.com", response.Params["Email"].ToString());
        }
    }
}