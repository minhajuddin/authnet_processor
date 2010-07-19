using System.Xml.Linq;

namespace Authnet.Parsers {
    public class UpdateCustomerShippingAddressParser : ParserBase, IParser {
        public Response Parse(string rawXml) {
            var doc = XDocument.Parse(rawXml);
            var root = doc.Descendants(_namespace + "updateCustomerShippingAddressResponse");
            var response = GetBasicResponse(root);
            return response;
        }
    }
}