namespace Authnet.Gateways {
    public interface ICustomerInformationManager {
        long[] GetCustomerProfileIds();
        Response Create(IProfileAttributes profileAttributes);
        Response CreatePaymentProfile(IProfileAttributes profile, IAddressAttributes billingAddress, ICreditCardAttributes creditCardInfo);
        Response Create(IProfileAttributes profileAttributes, IAddressAttributes shippingAddress);
        Response Get(IProfileAttributes profileAttributes);
        Response Get(IProfileAttributes profileAttributes, IPaymentProfileAttributes paymentProfileAttributes);
        Response Get(IProfileAttributes profileAttributes, IAddressAttributes addressAttributes);
        Response Delete(IProfileAttributes profileAttributes);
        Response Delete(IProfileAttributes profileAttributes, IPaymentProfileAttributes paymentProfileAttributes);
        Response Delete(IProfileAttributes profileAttributes, IAddressAttributes shippingAddressAttributes);
        Response Update(IProfileAttributes profileAttributes);
        Response Update(IProfileAttributes profile, IAddressAttributes billingAddress, ICreditCardAttributes creditCardInfo, IPaymentProfileAttributes paymentProfileAttributes);
        Response Update(IProfileAttributes profile, IAddressAttributes shippingAddress);
    }
}