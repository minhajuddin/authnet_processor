using System;
using System.Collections.Generic;
using Authnet.Model;
using Authnet.Net;
using Authnet.Parsers;
using Authnet.Templating;

namespace Authnet.Gateways {
    public class CustomerInformationManager : GatewayBase, ICustomerInformationManager {
        public CustomerInformationManager(TemplateFactory templateFactory, Authentication authentication)
            : base(templateFactory, authentication) {
        }

        // GetCustomerProfileIds
        public long[] GetCustomerProfileIds() {
            var connection = new Connection(_url);

            var template = _templateFactory.GetInstance("getCustomerProfileIds.spark");

            template.Authentication = _authentication;
            var response = connection.Request("post", template.Render(null), null);
            //Console.WriteLine(response);
            return new long[] { };
        }

        public Response Create(IProfileAttributes profileAttributes) {
            return GetResponse(profileAttributes, "createCustomerProfileRequest.spark", new CreateCustomerProfileParser());
        }

        public Response CreatePaymentProfile(IProfileAttributes profile, IAddressAttributes billingAddress, ICreditCardAttributes creditCardInfo) {
            var paymentProfileAttributes = new Dictionary<string, object>();
            paymentProfileAttributes.Add("profileAttributes", profile);
            paymentProfileAttributes.Add("billingAddressAttributes", billingAddress);
            paymentProfileAttributes.Add("creditCardAttributes", creditCardInfo);
            return GetResponse(paymentProfileAttributes, "createCustomerPaymentProfileRequest.spark", new CreateCustomerPaymentProfileParser());
        }

        public Response Create(IProfileAttributes profileAttributes, IAddressAttributes shippingAddress) {
            var shippingAddressAttributes = new Dictionary<string, object>();
            shippingAddressAttributes.Add("profileAttributes", profileAttributes);
            shippingAddressAttributes.Add("shippingAddressAttributes", shippingAddress);

            return GetResponse(shippingAddressAttributes, "createCustomerShippingAddressRequest.spark", new CreateCustomerShippingAddressParser());
        }

        //public Response Create(IAddressAttributes shippingAddress,IProfileAttributes profileAttributes) {

        //    return GetResponse(shippingAddress, "createCustomerPaymentProfileRequest.spark", new CreateCustomerPaymentProfileParser());
        //}

    }
}