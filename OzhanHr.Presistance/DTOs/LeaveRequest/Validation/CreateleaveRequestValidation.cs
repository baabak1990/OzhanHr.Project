using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using OzhanHr.Application.Contracts.Presistance.Repository;

namespace OzhanHr.Application.DTOs.LeaveRequest.Validation
{
    public class CreateleaveRequestValidation:AbstractValidator<CreateLeaveRequestDTO>
    {
        private readonly IleaveRequestRepository _leaveRequestRepository;
        public CreateleaveRequestValidation(IleaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            Include(new IleaveRequestValidation(_leaveRequestRepository));


        }
    }
}
