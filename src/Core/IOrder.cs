namespace Authnet {
    public interface IOrder {
        double Amount { get; set; }
        string Description { get; set; }
    }
}