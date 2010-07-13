using System;
using System.Linq;
using System.Xml.Linq;

namespace Authnet.Parsers {
    public class CreateCustomerProfileParser : IParser {
        public Response Parse(string rawXml) {
            var response = new Response();
            var set = new ParameterSet();

            var doc = XDocument.Parse(rawXml);
            XNamespace schema = "AnetApi/xml/v1/schema/AnetApiSchema.xsd";
            var root = doc.Descendants(schema + "createCustomerProfileResponse");
            response.ResultCode = root.Descendants(schema + "resultCode").First().Value;
            response.Message = root.Descendants(schema + "text").First().Value;
            set["customerProfileId"] = root.Descendants(schema + "customerProfileId").First().Value;

            response.ParameterSet = set;
            return response;
        }
    }
}