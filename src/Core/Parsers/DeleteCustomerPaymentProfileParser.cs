using System.Xml.Linq;

namespace Authnet.Parsers {
    public class DeleteCustomerPaymentProfileParser : ParserBase, IParser {
        public Response Parse(string rawXml) {
            var doc = XDocument.Parse(rawXml);
            var root = doc.Descendants(_namespace + "deleteCustomerPaymentProfileResponse");
            var response = GetBasicResponse(root);
            return response;
        }
    }
}