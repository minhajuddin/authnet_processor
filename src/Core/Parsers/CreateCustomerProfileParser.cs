using System.Linq;
using System.Xml.Linq;

namespace Authnet.Parsers {
    public class CreateCustomerProfileParser : ParserBase, IParser {

        public Response Parse(string rawXml) {

            var doc = XDocument.Parse(rawXml);
            var root = doc.Descendants(_namespace + "createCustomerProfileResponse");
            var response = GetBasicResponse(root);
            response.Params["customerProfileId"] = root.Descendants(_namespace + "customerProfileId").First().Value;

            return response;
        }
    }
}