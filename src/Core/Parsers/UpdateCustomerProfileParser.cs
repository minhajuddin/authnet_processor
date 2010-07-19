namespace Authnet.Parsers {
    public class UpdateCustomerProfileParser : ParserBase, IParser {
        public Response Parse(string rawXml) {
            return GetBasicResponse(rawXml, "updateCustomerProfileResponse");
        }
    }
}