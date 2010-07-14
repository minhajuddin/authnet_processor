namespace Authnet.Gateways {
    public interface IGateway {
        Response Charge(ICustomer customer);//should probably take something else, maybe a payment identifier or something
        Response Refund(ICustomer customer);//should take an amount and some kind of payment id
        Response Void(ICustomer customer);//should take the transaction id
    }
}