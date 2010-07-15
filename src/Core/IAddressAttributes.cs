namespace Authnet {
    public interface IAddressAttributes {
        string GateWayId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Company { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zip { get; set; }
        string Country { get; set; }
        string PhoneNumber { get; set; }
        string FaxNumber { get; set; }
    }
}