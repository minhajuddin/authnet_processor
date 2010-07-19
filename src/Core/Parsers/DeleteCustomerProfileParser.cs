namespace Authnet.Parsers {
    public class DeleteCustomerProfileParser : ParserBase, IParser {
        public Response Parse(string rawXml) {
            return GetBasicResponse(rawXml, "deleteCustomerProfileResponse");
        }
    }
}