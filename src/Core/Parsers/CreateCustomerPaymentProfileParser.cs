using System.Linq;
using System.Xml.Linq;

namespace Authnet.Parsers {
    public class CreateCustomerPaymentProfileParser : ParserBase, IParser {
        public Response Parse(string rawXml) {

            var doc = XDocument.Parse(rawXml);
            var root = doc.Descendants(_namespace + "createCustomerPaymentProfileResponse");
            var response = GetBasicResponse(root);

            if (response.Success) {
                response.Params["customerPaymentProfileId"] = root.Descendants(_namespace + "customerPaymentProfileId").First().Value;
                response.Params["validationDirectResponse"] = root.Descendants(_namespace + "validationDirectResponse").First().Value;
            }

            return response;
        }
    }
}