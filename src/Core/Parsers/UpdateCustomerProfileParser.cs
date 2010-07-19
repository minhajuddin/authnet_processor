using System;
using System.Xml.Linq;

namespace Authnet.Parsers {
    public class UpdateCustomerProfileParser : ParserBase, IParser {
        public Response Parse(string rawXml) {
            var doc = XDocument.Parse(rawXml);
            var root = doc.Descendants(_namespace + "updateCustomerProfileResponse");
            var response = GetBasicResponse(root);
            return response;
        }
    }
}