using PaymentAPI.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models
{
    public class Card
    {
        [Required]
        [RegularExpression("^4[0-9]{12}(?:[0-9]{3})?$", ErrorMessage = "Invalid card number")]
        public string CreditCardNumber { get; set; }
        
        [Required]
        public string CardHolder { get; set; }
        
        [Required]
        [IsNotPastDate]
        public DateTime ExpirationDate { get; set; }
        
        [StringLength(3)]
        public string SecurityCode { get; set; }
        
        [Required]
        [RangeAttribute(0,double.MaxValue,ErrorMessage ="Only positive amount allowed")]
        public decimal Amount { get; set; }
    }
}