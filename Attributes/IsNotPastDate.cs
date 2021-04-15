using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Attributes
{
    public class IsNotPastDate : ValidationAttribute
    {
        public IsNotPastDate() :base("{0} is in the past")
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(DateTime.Compare(DateTime.Today,Convert.ToDateTime(value)) <= 0)
            {
                return ValidationResult.Success; 
            }

            var errorMessage = FormatErrorMessage((validationContext.DisplayName));
            return new ValidationResult(errorMessage);
        }
    }
}