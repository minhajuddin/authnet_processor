using System.Linq;
using System.Xml.Linq;

namespace Authnet.Parsers {
    public class CreateCustomerProfileTransactionParser : ParserBase, IParser {
        public Response Parse(string rawXml) {

            var doc = XDocument.Parse(rawXml);
            var root = doc.Descendants(_namespace + "createCustomerProfileTransactionResponse");
            var response = GetBasicResponse(root);
            response.Params["directResponse"] = root.Descendants(_namespace + "directResponse").First().Value;

            return response;
        }
    }
}