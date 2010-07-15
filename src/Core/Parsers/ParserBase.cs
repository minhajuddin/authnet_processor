using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Authnet.Parsers {
    public abstract class ParserBase {
        protected XNamespace _namespace;

        protected ParserBase() {
            _namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd";
        }

        protected Response GetBasicResponse(IEnumerable<XElement> root) {
            //populate the basic info
            // and see if the response is successful
            return new Response
                       {
                           ResultCode = root.Descendants(_namespace + "resultCode").First().Value,
                           Message = root.Descendants(_namespace + "text").First().Value
                       };
        }
    }
}