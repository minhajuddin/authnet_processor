using System.Linq;
using System.Xml.Linq;

namespace Authnet.Parsers {
    public class CreateCustomerProfileParser : ParserBase, IParser {

        public Response Parse(string rawXml) {

            _doc = XDocument.Parse(rawXml);
            var root = _doc.Descendants(_namespace + "createCustomerProfileResponse");
            var response = GetBasicResponse(root);

            if (response.Success) {
                response.Params["customerProfileId"] = root.Descendants(_namespace + "customerProfileId").First().Value;
            }
            if (response.Code == "E00027") {

                response.Params["validationDirectResponseString"] = root.Descendants(_namespace + "validationDirectResponse").First().Value;
                response.Params["validationDirectResponseHash"] = DirectResponseParser.Parse(response.Params["validationDirectResponseString"]);

            }

            return response;
        }
    }
}