using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace OzhanHr.Application.DTOs.LeaveType.Validation
{
    public class LeaveTypeValidation:AbstractValidator<LeaveTypeDTO>
    {
        public LeaveTypeValidation()
        {
            RuleFor(l => l.Name)
                .NotNull().WithMessage("{PropertyName} Can`t be Null Or Empty")
                .MaximumLength(100).WithMessage("{PropertyName} Can`t be more than {ComparisionValue}");
            RuleFor(r => r.Id)
                .NotNull().WithMessage("{PropertyName} Must Be present ");
        }
    }
}
