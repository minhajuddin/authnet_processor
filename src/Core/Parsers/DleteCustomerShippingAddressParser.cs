using System;
using System.Xml.Linq;

namespace Authnet.Parsers {
    public class DleteCustomerShippingAddressParser : ParserBase, IParser {
        public Response Parse(string rawXml) {
            var doc = XDocument.Parse(rawXml);
            var root = doc.Descendants(_namespace + "deleteCustomerShippingAddressResponse");
            var response = GetBasicResponse(root);
            return response;

        }
    }
}