using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using OzhanHr.Application.Contracts.Presistance.Repository;

namespace OzhanHr.Application.DTOs.LeaveRequest.Validation
{
    public class IleaveRequestValidation : AbstractValidator<IleaveRequestDTO>
    {
        private readonly IleaveRequestRepository _leaveRequestRepository;

        public IleaveRequestValidation(IleaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;


            RuleFor(r => r.StartDate)
                .NotNull().WithMessage("{PropertyName} Should Be Present");

            RuleFor(r => r.StartDate)
           .LessThan(r => r.EndDate)
                .WithMessage("{PropertyName} Should be lesser Than {ComparisionData}");

            RuleFor(r => r.EndDate)
                .NotNull().WithMessage("{PropertyName} Should Be Present");

            RuleFor(r => r.StartDate)
                .GreaterThan(r => r.EndDate)
                .WithMessage("{PropertyName} Should be lesser Than {ComparisionData}");

            RuleFor(l => l.LeaveType_Id)
                .GreaterThan(0)
                .WithMessage("{propertyName} Should be Greater than {ComparisionValue}")
                .MustAsync(async (id, token) =>
                {
                    var validation = await _leaveRequestRepository.IsExist(id);
                    return !validation;
                });
        }
    }

}
