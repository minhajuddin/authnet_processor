using System.Linq;
using System.Xml.Linq;

namespace Authnet.Parsers {
    public class GetCustomerProfileParser : ParserBase, IParser {
        public Response Parse(string rawXml) {
            var doc = XDocument.Parse(rawXml);
            var root = doc.Descendants(_namespace + "getCustomerProfileResponse");
            var response = GetBasicResponse(root);
            response.Params["Description"] = root.Descendants(_namespace + "description").First().Value;
            response.Params["Email"] = root.Descendants(_namespace + "email").First().Value;

            return response;
        }
    }
}