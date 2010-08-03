namespace Authnet.Gateways {
    public interface IGateway {
        Response Charge(IProfileAttributes profileAttributes, IPaymentProfileAttributes paymentProfileAttributes, IOrder order);//should probably take something else, maybe a payment identifier or something
        Response Refund(IProfileAttributes profileAttributes, IPaymentProfileAttributes paymentProfileAttributes, IOrder order, ITransaction transaction);//should probably take something else, maybe a payment identifier or something
        Response Void(IProfileAttributes profileAttributes, IPaymentProfileAttributes paymentProfileAttributes, ITransaction transaction);//should probably take something else, maybe a payment identifier or something
        //Response Refund(ICustomer customer);//should take an amount and some kind of payment id
        //Response Void(ICustomer customer);//should take the transaction id
    }
}