namespace Authnet.Gateways {
    public interface ICustomerInformationManager {
        long[] GetCustomerProfileIds();
        Response Create(IProfileAttributes profileAttributes);
        Response CreatePaymentProfile(IProfileAttributes profile, IAddressAttributes billingAddress, ICreditCardAttributes creditCardInfo);
        Response Create(IProfileAttributes profileAttributes, IAddressAttributes shippingAddress);
    }
}