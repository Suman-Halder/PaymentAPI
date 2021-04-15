using PaymentAPI.BusinessLayer;
using PaymentAPI.Models;
using System.Web.Http;

namespace PaymentAPI.Controllers
{
    public class ProcessPaymentController : ApiController
    {
        public IHttpActionResult Post(Card card)
        {
            bool isPaymentProcessed = false;

            if (ModelState.IsValid)
            {
                try
                {
                    RuleEngine ruleEngine = new RuleEngine();
                    isPaymentProcessed = ruleEngine.ProcessPayment(card);
                    if (isPaymentProcessed)
                        return Ok();
                    else
                        return InternalServerError();
                }
                catch
                {
                    return InternalServerError();
                }
                
            }

            return BadRequest();
        }
    }
}
