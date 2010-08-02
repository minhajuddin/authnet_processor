namespace Authnet {
    public interface IPaymentProfileAttributes {
        string GateWayId { get; set; }
        string MaskedCreditCard { get; set; }
    }
}