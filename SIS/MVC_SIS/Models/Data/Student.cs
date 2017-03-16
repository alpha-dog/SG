using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Student : IValidatableObject
    {
        [Required(ErrorMessage = "A problem was encountered generating your student ID. Please contact Addmissions")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string LastName { get; set; }
        public decimal GPA { get; set; }
        public Address Address { get; set; }

        [Required(ErrorMessage = "Please enter a Major")]
        public Major Major { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
        List<ValidationResult> errors = new List<ValidationResult>();

            if(GPA > 4 || GPA < 0)
            {
                errors.Add(new ValidationResult("Your GPA needs to be between 0 and 4", new[] { "GPA" }));
            }
            return errors;
        }
    }
}