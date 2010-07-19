using System.Linq;
using System.Xml.Linq;

namespace Authnet.Parsers {
    public class UpdateCustomerPaymentProfileParser : ParserBase, IParser {
        public Response Parse(string rawXml) {
            var doc = XDocument.Parse(rawXml);
            var root = doc.Descendants(_namespace + "updateCustomerPaymentProfileResponse");
            var response = GetBasicResponse(root);
            response.Params["validationDirectResponse"] = root.Descendants(_namespace + "validationDirectResponse").First().Value;
            return response;
        }
    }
}