namespace Authnet.Parsers {
    public class DleteCustomerShippingAddressParser : ParserBase, IParser {
        public Response Parse(string rawXml) {
            return GetBasicResponse(rawXml, "deleteCustomerShippingAddressResponse");
        }
    }
}