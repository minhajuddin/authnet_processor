namespace Authnet {
    public interface ICustomerInformationManager {
        long[] GetCustomerProfileIds();
        Response CreateCustomerProfile(ICustomer customer);
    }
}