namespace Authnet {
    public interface ITransaction {
        double Amount { get; set; }
        string ProfileId { get; set; }
        string PaymentProfileId { get; set; }
        string InVoiceNumber { get; set; }
        string Description { get; set; }
        string PurchaseOrderNumber { get; set; }
        bool TaxExempt { get; set; }
        bool RecurringBilling { get; set; }
    }
}