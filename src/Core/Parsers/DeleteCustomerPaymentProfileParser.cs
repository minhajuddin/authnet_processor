namespace Authnet.Parsers {
    public class DeleteCustomerPaymentProfileParser : ParserBase, IParser {
        public Response Parse(string rawXml) {
            return GetBasicResponse(rawXml, "deleteCustomerPaymentProfileResponse");
        }
    }
}