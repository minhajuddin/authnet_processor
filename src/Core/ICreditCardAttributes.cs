namespace Authnet {
    public interface ICreditCardAttributes {
        string CardNumber { get; set; }
        string ExpirationDate { get; set; }
    }
}