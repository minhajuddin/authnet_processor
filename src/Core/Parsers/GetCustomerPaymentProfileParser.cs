using System.Linq;
using System.Xml.Linq;

namespace Authnet.Parsers {
    public class GetCustomerPaymentProfileParser : ParserBase, IParser {
        public Response Parse(string rawXml) {
            var doc = XDocument.Parse(rawXml);
            var root = doc.Descendants(_namespace + "getCustomerPaymentProfileResponse");
            var response = GetBasicResponse(root);

            //TODO: Need to take mote parameters
            response.Params["customerPaymentProfileId"] = root.Descendants(_namespace + "customerPaymentProfileId").First().Value;


            return response;
        }
    }
}