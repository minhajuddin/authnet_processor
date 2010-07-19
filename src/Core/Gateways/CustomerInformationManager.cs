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

        public Response Get(IProfileAttributes profileAttributes) {
            return GetResponse(profileAttributes, "getCustomerProfileRequest.spark", new GetCustomerProfileParser());
        }

        public Response Get(IProfileAttributes profileAttributes, IPaymentProfileAttributes paymentProfileAttributes) {
            var getpaymentProfileAttributes = new Dictionary<string, object>();
            getpaymentProfileAttributes.Add("profileAttributes", profileAttributes);
            getpaymentProfileAttributes.Add("paymentProfileAttributes", paymentProfileAttributes);
            return GetResponse(getpaymentProfileAttributes, "getCustomerPaymentProfileRequest.spark", new GetCustomerPaymentProfileParser());
        }

        public Response Get(IProfileAttributes profileAttributes, IAddressAttributes addressAttributes) {
            var getShippingAddressAttributes = new Dictionary<string, object>();
            getShippingAddressAttributes.Add("profileAttributes", profileAttributes);
            getShippingAddressAttributes.Add("addressAttributes", addressAttributes);
            return GetResponse(getShippingAddressAttributes, "getCustomerShippingAddressRequest.spark", new GetCustomerShippingAddressParser());
        }

        public Response Delete(IProfileAttributes profileAttributes) {
            return GetResponse(profileAttributes, "deleteCustomerProfileRequest.spark", new DeleteCustomerProfileParser());
        }

        public Response Delete(IProfileAttributes profileAttributes, IPaymentProfileAttributes paymentProfileAttributes) {
            var deletepaymentProfileAttributes = new Dictionary<string, object>();
            deletepaymentProfileAttributes.Add("profileAttributes", profileAttributes);
            deletepaymentProfileAttributes.Add("paymentProfileAttributes", paymentProfileAttributes);
            return GetResponse(deletepaymentProfileAttributes, "deleteCustomerPaymentProfileRequest.spark", new DeleteCustomerPaymentProfileParser());
        }

        public Response Delete(IProfileAttributes profileAttributes, IAddressAttributes shippingAddressAttributes) {
            var deleteshippingAddressAttributes = new Dictionary<string, object>();
            deleteshippingAddressAttributes.Add("profileAttributes", profileAttributes);
            deleteshippingAddressAttributes.Add("shippingAddressAttributes", shippingAddressAttributes);
            return GetResponse(deleteshippingAddressAttributes, "deleteCustomerShippingAddressRequest.spark", new DeleteCustomerPaymentProfileParser());
        }

        public Response Update(IProfileAttributes profileAttributes) {
            return GetResponse(profileAttributes, "updateCustomerProfileRequest.spark", new UpdateCustomerProfileParser());
        }

        public Response Update(IProfileAttributes profile, IAddressAttributes billingAddress, ICreditCardAttributes creditCardInfo, IPaymentProfileAttributes paymentProfileAttributes) {
            var updatePaymentProfileAttributes = new Dictionary<string, object>();
            updatePaymentProfileAttributes.Add("profileAttributes", profile);
            updatePaymentProfileAttributes.Add("paymentProfileAttributes", paymentProfileAttributes);
            updatePaymentProfileAttributes.Add("billingAddressAttributes", billingAddress);
            updatePaymentProfileAttributes.Add("creditCardAttributes", creditCardInfo);
            return GetResponse(updatePaymentProfileAttributes, "updateCustomerPaymentProfileRequest.spark", new UpdateCustomerPaymentProfileParser());
        }

        public Response Update(IProfileAttributes profile, IAddressAttributes shippingAddress) {
            var shippingAddressAttributes = new Dictionary<string, object>();
            shippingAddressAttributes.Add("profileAttributes", profile);
            shippingAddressAttributes.Add("shippingAddressAttributes", shippingAddress);

            return GetResponse(shippingAddressAttributes, "updateCustomerShippingAddressRequest.spark", new UpdateCustomerShippingAddressParser());
        }

        //public Response Create(IAddressAttributes shippingAddress,IProfileAttributes profileAttributes) {

        //    return GetResponse(shippingAddress, "createCustomerPaymentProfileRequest.spark", new CreateCustomerPaymentProfileParser());
        //}

    }
}