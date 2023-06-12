using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using OzhanHr.Application.Contracts.Presistance.Repository;

namespace OzhanHr.Application.DTOs.LeaveAllocation.Validation
{
    public class ChangeleaveAllocationValidation:AbstractValidator<ChangeLeaveAllocationDTO>
    {
        private readonly ILeaveAllocationRepository _allocationRepository;

        public ChangeleaveAllocationValidation(ILeaveAllocationRepository allocationRepository)
        {
            _allocationRepository = allocationRepository;
            Include(new LeaveAllocationValidation(_allocationRepository));

            RuleFor(l => l.Id)
                .NotNull().WithMessage("{PropertyName} Must Be Present !!");
        }
    }
}
