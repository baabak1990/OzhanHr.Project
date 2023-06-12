using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace OzhanHr.Application.DTOs.LeaveType.Validation
{
    public class CreateLeaveTypeValidation:AbstractValidator<CreateLeaveTypeDTO>
    {
        public CreateLeaveTypeValidation()
        {
            RuleFor(l => l.Name)
                .NotNull().WithMessage("{PropertyName} Can`t be Null Or Empty")
                .MaximumLength(100).WithMessage("{PropertyName} Can`t be more than {ComparisionValue}");

            RuleFor(r => r.DefaultDays)
                .GreaterThan(0).WithMessage("{PropertyName} Should be greater than {ComparisionValue}")
                .LessThan(40).WithMessage("{PropertyName} Should be Lesser than {ComparisionValue}");
        }
    }
}
