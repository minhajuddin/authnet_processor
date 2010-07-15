using Authnet.Model;
using Authnet.Net;
using Authnet.Parsers;
using Authnet.Templating;

namespace Authnet {
    public class CustomerInformationManager : GatewayBase, ICustomerInformationManager {
        public CustomerInformationManager(TemplateFactory templateFactory, Authentication authentication)
            : base(templateFactory, authentication) {
        }

        public long[] GetCustomerProfileIds() {
            var connection = new Connection(_url);

            var template = _templateFactory.GetInstance("getCustomerProfileIds.spark");

            template.Authentication = _authentication;
            var response = connection.Request("post", template.Render(null), null);
            //Console.WriteLine(response);
            return new long[] { };
        }

        public Response CreateCustomerProfile(ICustomer customer) {
            return GetResponse(customer, "createCustomerProfileRequest.spark", new CreateCustomerProfileParser());
        }

        public Response CreatePaymentProfile(ICustomer customer) {
            return GetResponse(customer, "createCustomerPaymentProfileRequest.spark", new CreateCustomerPaymentProfileParser());
        }

        public Response CreateCustomerShippingAddress(IAddressAttributes customerAddress) {
            //remove dups
            var parser = new CreateCustomerPaymentProfileParser();
            var connection = new Connection(_url);
            var template = _templateFactory.GetInstance("createCustomerShippingAddressRequest.spark");
            template.Authentication = _authentication;
            var requestBody = template.Render(customerAddress);
            var response = connection.Request("post", requestBody, null);
            return parser.Parse(response);
        }

        //TODO:This needs to go to IGateway
        public Response CreateCustomerProfileTransaction(ITransaction transaction) {
            var parser = new CreateCustomerPaymentProfileParser();
            var connection = new Connection(_url);
            var template = _templateFactory.GetInstance("createCustomerProfileTransactionRequest.spark");
            template.Authentication = _authentication;
            var requestBody = template.Render(transaction);
            var response = connection.Request("post", requestBody, null);
            return parser.Parse(response);

        }

    }
}

