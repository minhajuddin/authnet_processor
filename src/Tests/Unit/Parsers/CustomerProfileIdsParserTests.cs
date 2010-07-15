using System;
using System.Linq;
using Authnet;
using NUnit.Framework;
using System.Xml.Linq;

namespace Tests.Unit.Parsers {
    [TestFixture]
    public class CustomerProfileIdsParserTests {
        [Test]
        public void CanParse() {
            var parser = new CustomerProfileIdsParser();
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
                            </getCustomerProfileIdsResponse>";

            var set = parser.Parse(rawXml);
            Assert.AreEqual("I00001", set["code"].ToString());
            Assert.AreEqual("Successful.", set["message"].ToString());

        }
    }

    public class CustomerProfileIdsParser {
        public Hash Parse(string rawXml) {

            var doc = XDocument.Parse(rawXml);
            var set = new Hash();
            XNamespace schema = "AnetApi/xml/v1/schema/AnetApiSchema.xsd";
            var root = doc.Descendants(schema + "getCustomerProfileIdsResponse");
            Console.WriteLine(root);
            set["message"] = root.Descendants(schema + "messages").First().Descendants(schema + "text").First().Value;
            set["code"] = root.Descendants(schema + "messages").First().Descendants(schema + "code").First().Value;
            // set["message"] = root.Descendants(schema + "messages").First().Element("text").ToString();
            return set;
        }
    }
}