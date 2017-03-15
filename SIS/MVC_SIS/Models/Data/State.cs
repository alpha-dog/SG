using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class State : IValidatableObject

    {
        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (StateAbbreviation.Length != 2)
            {
                errors.Add(new ValidationResult("Please enter a two character state abbreviation", new[] { "StateAbbreviation" }));
            }
            return errors;
        }
    }
}