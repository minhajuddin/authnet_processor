using System.Linq;
using System.Xml.Linq;

namespace Authnet.Parsers {
    public class CreateCustomerShippingAddressParser : ParserBase, IParser {
        public Response Parse(string rawXml) {

            var doc = XDocument.Parse(rawXml);
            XNamespace schema = "AnetApi/xml/v1/schema/AnetApiSchema.xsd";
            var root = doc.Descendants(schema + "createCustomerShippingAddressResponse");
            var response = GetBasicResponse(root);
            response.Params["customerAddressId"] = root.Descendants(schema + "customerAddressId").First().Value;

            return response;
        }
    }
}