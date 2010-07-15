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

        public Response Create(IProfileAttributes profile, IAddressAttributes billingAddress, ICreditCardAttributes creditCardInfo) {
            return GetResponse(profile, "createCustomerPaymentProfileRequest.spark", new CreateCustomerPaymentProfileParser());
        }

        public Response Create(IAddressAttributes shippingAddress) {

            return GetResponse(shippingAddress, "createCustomerPaymentProfileRequest.spark", new CreateCustomerPaymentProfileParser());
        }

    }
}