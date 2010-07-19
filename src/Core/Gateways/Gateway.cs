using System;
using System.Collections.Generic;
using Authnet.Model;
using Authnet.Parsers;
using Authnet.Templating;

namespace Authnet.Gateways {
    public class Gateway : GatewayBase, IGateway {
        public Gateway(TemplateFactory templateFactory, Authentication authentication)
            : base(templateFactory, authentication) {
        }

        //create a Charge method which will do only authcatpure
        //change ITransaction to TransactionType and make it protected
        public Response Charge(IProfileAttributes profileAttributes, IPaymentProfileAttributes paymentProfileAttributes, IOrder order) {
            var chargeAttributes = new Dictionary<string, object>();
            chargeAttributes.Add("profile", profileAttributes);
            chargeAttributes.Add("paymentProfile", paymentProfileAttributes);
            chargeAttributes.Add("order", order);
            return GetResponse(chargeAttributes, "createCustomerProfileTransactionRequestAuthCapture.spark", new CreateCustomerProfileTransactionParser());
        }

        public Response Refund(ICustomer customer) {
            throw new NotImplementedException();
        }

        public Response Void(ICustomer customer) {
            throw new NotImplementedException();
        }
    }
}