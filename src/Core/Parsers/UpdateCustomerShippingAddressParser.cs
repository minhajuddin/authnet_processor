namespace Authnet.Parsers {
    public class UpdateCustomerShippingAddressParser : ParserBase, IParser {
        public Response Parse(string rawXml) {
            return GetBasicResponse(rawXml, "updateCustomerProfileResponse");
        }
    }
}