using System;
using Authnet.Extensions;

namespace Authnet.Parsers {
    public static class DirectResponseParser {
        private const int MINIMUM_NUMBER_OF_TOKENS = 40;
        private static Hash _ditectResponseHash;

        static DirectResponseParser() {
            _ditectResponseHash = new Hash();
        }

        public static Hash Parse(string directResponseString) {

            if (directResponseString.IsEmpty()) {
                return null;
            }

            string[] dataTokens = directResponseString.Split(',');

            if (dataTokens.Length < MINIMUM_NUMBER_OF_TOKENS) {
                throw new ArgumentException("Invalid number of tokens in the direct validation response string");
            }

            _ditectResponseHash["PaymentGatewayTransactionId"] = dataTokens[6];
            _ditectResponseHash["TransactionType"] = dataTokens[11];
            _ditectResponseHash["Amount"] = dataTokens[9];
            _ditectResponseHash["ResponseReasonText"] = dataTokens[3];

            //DirectResponse transaction = new DirectResponse
            //{
            //    ResponseCode = byte.Parse(dataTokens[0]),
            //    ResponseSubCode = byte.Parse(dataTokens[1]),
            //    ResponseReasonCode = byte.Parse(dataTokens[2]),
            //    AuthorizationCode = dataTokens[4],
            //    AvsResponse = dataTokens[5],
            //    PaymentGatewayTransactionId = long.Parse(dataTokens[6]),
            //    Amount = decimal.Parse(dataTokens[9]),
            //    TransactionType = dataTokens[11],
            //    CardCodeResponse = dataTokens[38],
            //    CardHolderAuthenticationVerifcationResponse = dataTokens[39],
            //    RawResponse = valData,
            //    ResponseReasonText = dataTokens[3]
            //};
            return _ditectResponseHash;

        }
    }
}