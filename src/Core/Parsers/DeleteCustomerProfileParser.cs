using System;
using System.Linq;
using System.Xml.Linq;

namespace Authnet.Parsers {
    public class DeleteCustomerProfileParser : ParserBase, IParser {
        public Response Parse(string rawXml) {
            var doc = XDocument.Parse(rawXml);
            var root = doc.Descendants(_namespace + "deleteCustomerProfileResponse");
            var response = GetBasicResponse(root);
            return response;
        }
    }
}