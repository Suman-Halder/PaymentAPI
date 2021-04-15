namespace PaymentAPI.ExternalService
{
    public interface IExternalService
    {
        bool IsAvailable { get; set; }
        int RetryCount { get; set; }
        bool ProcessPayment();
    }
}
