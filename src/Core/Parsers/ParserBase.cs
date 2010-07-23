using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Authnet.Parsers {
    public abstract class ParserBase {
        protected XNamespace _namespace;
        protected XDocument _doc;
        protected ParserBase() {
            _namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd";
        }

        protected Response GetBasicResponse(string xml, string rootElementName) {
            var doc = XDocument.Parse(xml);
            var root = doc.Descendants(_namespace + rootElementName);
            return GetBasicResponse(root);
        }

        protected Response GetBasicResponse(IEnumerable<XElement> root) {
            //populate the basic info
            // and see if the response is successful
            if (0 == root.Count()) {
                root = _doc.Descendants(_namespace + "ErrorResponse");
            }
            var resultCode = root.Descendants(_namespace + "resultCode").First().Value;
            var response = new Response
                               {
                                   Success = resultCode == "Ok" ? true : false,
                                   Message = root.Descendants(_namespace + "text").First().Value,
                                   Code = root.Descendants(_namespace + "code").First().Value

                               };
            return response;
        }

    }
}