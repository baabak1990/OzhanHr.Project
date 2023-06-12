using OzhanHr.Application.Contracts.Presistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace OzhanHr.Application.DTOs.LeaveRequest.Validation
{
    public class UpdateLeaveRequestValidation:AbstractValidator<ChangeLeaveRequestStatuesDTO>
    {
        private readonly IleaveRequestRepository _leaveRequestRepository;
        public UpdateLeaveRequestValidation(IleaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            Include(new IleaveRequestValidation(_leaveRequestRepository));

            RuleFor(r => r.Id)
                .NotNull().WithMessage("{PropertyName} Must Be present ");

        }
    }
}
