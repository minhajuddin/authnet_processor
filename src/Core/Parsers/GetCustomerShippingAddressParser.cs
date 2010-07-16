using System;
using System.Linq;
using System.Xml.Linq;

namespace Authnet.Parsers {
    public class GetCustomerShippingAddressParser : ParserBase, IParser {
        public Response Parse(string rawXml) {
            var doc = XDocument.Parse(rawXml);
            var root = doc.Descendants(_namespace + "getCustomerShippingAddressResponse");
            var response = GetBasicResponse(root);

            //TODO: Need to take mote parameters
            response.Params["customerAddressId"] = root.Descendants(_namespace + "customerAddressId").First().Value;


            return response;
        }
    }
}