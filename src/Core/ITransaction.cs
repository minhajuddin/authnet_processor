namespace Authnet {
    public interface ITransaction {
        string GateWayId { get; set; }
        TransactionType Type { get; set; }
    }

    public enum TransactionType {
        AuthOnly,
        AuthCapture,
        CaptureOnly
    }
}