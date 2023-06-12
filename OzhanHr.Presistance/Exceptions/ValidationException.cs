using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace OzhanHr.Application.Exceptions
{
    public class ValidationException:ApplicationException
    {
        public List<string> Errors { get; set; } = new List<string>();

        //This Validation Result Is Available In FluentValidation Lib
        public ValidationException(ValidationResult validation)
        {
            foreach (var error in validation.Errors)
            {
                //This Error is Our List which we have Already created!!!
                Errors.Add(error.ErrorMessage);
            }
        }
    }
}
