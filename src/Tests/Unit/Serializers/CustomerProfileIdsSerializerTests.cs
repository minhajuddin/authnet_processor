using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Xml.Linq;

namespace Tests.Unit.Serializers {

    [TestFixture]
    public class CustomerProfileIdsSerializerTests {
        [Test]
        public void CanSerialize() {
            var serializer = new CustomerProfileIdsSerializer();
            var rawXml = @"<?xml version='1.0' encoding='utf-8'?>
<getCustomerProfileIdsResponse xmlns='AnetApi/xml/v1/schema/AnetApiSchema.xsd'>
  <messages>
    <resultCode>Ok</resultCode>
    <message>
      <code>I00001</code>
      <text>Successful.</text>
    </message>
  </messages>
  <ids>
    <numericString>10000</numericString>
    <numericString>10001</numericString>
    <numericString>10002</numericString>
  </ids>
</getCustomerProfileIdsResponse>
";

            var set = serializer.Serialize( rawXml );
            Assert.AreEqual( "Successful.", set["message"] );
        }
    }

    public class CustomerProfileIdsSerializer {
        public ParameterSet Serialize( string rawXml ) {
            var doc = XDocument.Parse( rawXml );
            var set = new ParameterSet();
            XNamespace schema = "AnetApi/xml/v1/schema/AnetApiSchema.xsd";
            var root = doc.Descendants( schema + "getCustomerProfileIdsResponse" );
            Console.WriteLine( root );
            set["message"] = root.Descendants( "messages" ).First().Descendants( "text" ).First().Value;
            return set;
        }
    }
}
