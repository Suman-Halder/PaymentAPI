using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PaymentAPI.ExternalService;
using PaymentAPI.Models;

namespace PaymentAPI.BusinessLayer
{
    public class RuleEngine
    {
        bool isPaymentProcessed = false;        

        public bool ProcessPayment(Card card)
        {
            decimal amount = card.Amount;

            if (amount < 20)
            {
                IExternalService externalService = new CheapPaymentGateway();
                isPaymentProcessed = externalService.ProcessPayment();
            }
            else if (amount > 20 && amount <= 500)
            { 
                IExternalService externalService = new ExpensivePaymentGateway();
                if(externalService.IsAvailable)
                {
                    isPaymentProcessed = externalService.ProcessPayment();
                }
                else
                {
                    externalService = new CheapPaymentGateway();
                    while(externalService.RetryCount < 1)
                    {
                        isPaymentProcessed = externalService.ProcessPayment();
                    }
                }
            }
            else if (amount > 500)
            {
                IExternalService externalService = new PremiumPaymentGateway();
                while (externalService.RetryCount < 3)
                {
                    isPaymentProcessed = externalService.ProcessPayment();
                    if (isPaymentProcessed)
                        break;
                }
            }

            return isPaymentProcessed;
        }
    }
}