namespace Authnet.Model {
    public class Authentication {
        public string ApiLogin { get; protected set; }
        public string TransactionKey { get; protected set; }
        public string ApiUrl { get; protected set; }

        public Authentication(string apiLogin, string transactionKey, string apiUrl) {
            ApiLogin = apiLogin;
            TransactionKey = transactionKey;
            ApiUrl = apiUrl;
        }

    }
}