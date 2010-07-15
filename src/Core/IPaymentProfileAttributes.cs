namespace Authnet {
    public interface IPaymentProfileAttributes {
        string GateWayId { get; set; }
        IAddressAttributes BillIngAddress { get; set; }
        ICreditCardAttributes CreditCardInfo { get; set; }
    }
}