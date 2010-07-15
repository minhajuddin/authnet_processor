using System;
using Authnet.Model;
using Authnet.Net;
using Authnet.Parsers;
using Authnet.Templating;

namespace Authnet.Gateways {
    class Gateway : GatewayBase, IGateway {
        public Gateway(TemplateFactory templateFactory, Authentication authentication)
            : base(templateFactory, authentication) {
        }

        public Response Charge(ICustomer customer) {
            var parser = new CreateCustomerPaymentProfileParser();
            var connection = new Connection(_url);
            var template = _templateFactory.GetInstance("createCustomerProfileTransactionRequest.spark");
            template.Authentication = _authentication;
            var requestBody = template.Render(transaction);
            var response = connection.Request("post", requestBody, null);
            return parser.Parse(response);
        }

        public Response Refund(ICustomer customer) {
            throw new NotImplementedException();
        }

        public Response Void(ICustomer customer) {
            throw new NotImplementedException();
        }
    }
}