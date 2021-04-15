namespace PaymentAPI.ExternalService
{
    public class ExpensivePaymentGateway : IExternalService
    {
        public bool IsAvailable { get; set; } //Assume this property holds the availability status of the external payment gateway 
        public int RetryCount { get; set; }

        public bool ProcessPayment()
        {
            RetryCount += 1;

            //External payment API access code to write here
            return true; //Or return false if payment not processed
        }
    }
}