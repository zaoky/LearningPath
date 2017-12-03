using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Learning_Path.Models
{
    public class Min18YerasIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Customer customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            else if (customer.Birthday == null)
            {
                return new ValidationResult("Birthdate is required");
            }
            int age = DateTime.Today.Year - customer.Birthday.Value.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be at least 18 years old to go on a membershio.");
        }
    }
}