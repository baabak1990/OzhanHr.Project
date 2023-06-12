using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using OzhanHr.Application.Contracts.Presistance.Repository;

namespace OzhanHr.Application.DTOs.LeaveAllocation.Validation
{
    public class CreateLeaveAllocationValidation:AbstractValidator<CreateLeaveAllocationDTO>
    {
        private readonly ILeaveAllocationRepository _allocationRepository;
        public CreateLeaveAllocationValidation()
        {
            Include(new LeaveAllocationValidation(_allocationRepository));
        }
    }
}
