namespace Authnet.Gateways {
    public interface ICustomerInformationManager {
        long[] GetCustomerProfileIds();
        Response Create(IProfileAttributes profileAttributes);
        Response Create(IProfileAttributes profile, IAddressAttributes billingAddress, ICreditCardAttributes creditCardInfo);
        Response Create(IAddressAttributes shippingAddress);
    }
}