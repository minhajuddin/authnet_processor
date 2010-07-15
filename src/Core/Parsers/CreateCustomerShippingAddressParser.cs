using System.Linq;
using System.Xml.Linq;

namespace Authnet.Parsers {
    public class CreateCustomerShippingAddressParser : IParser {
        public Response Parse(string rawXml) {
            var response = new Response();
            var set = new Hash();

            var doc = XDocument.Parse(rawXml);
            XNamespace schema = "AnetApi/xml/v1/schema/AnetApiSchema.xsd";
            var root = doc.Descendants(schema + "createCustomerShippingAddressResponse");
            response.ResultCode = root.Descendants(schema + "resultCode").First().Value;
            response.Message = root.Descendants(schema + "text").First().Value;
            set["customerAddressId"] = root.Descendants(schema + "customerAddressId").First().Value;

            response.Params = set;
            return response;
        }
    }
}