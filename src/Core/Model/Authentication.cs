namespace Authnet.Core.Model {
    public class Authentication {
        public string ApiLogin { get; protected set; }
        public string TransactionKey { get; protected set; }

        public Authentication( string apiLogin, string transactionKey ) {
            ApiLogin = apiLogin;
            TransactionKey = transactionKey;
        }

    }
}
