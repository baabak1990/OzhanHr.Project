using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using OzhanHr.Application.Contracts.Presistance.Repository;

namespace OzhanHr.Application.DTOs.LeaveAllocation.Validation
{
    public class LeaveAllocationValidation : AbstractValidator<ILeaveAllocationValidation>
    {
        private readonly ILeaveAllocationRepository _allocationRepository;


        public LeaveAllocationValidation(ILeaveAllocationRepository allocationRepository)
        {
            _allocationRepository = allocationRepository;
            RuleFor(l => l.NumberOfDays)
                .LessThan(365).WithMessage("{propertyName} Should be lesser than {ComparisionValue}");
            RuleFor(l => l.Period)
                .LessThan(365).WithMessage("{propertyName} Should be lesser than {ComparisionValue}");
            RuleFor(l => l.LeaveType_Id)
                .GreaterThan(0)
                .WithMessage("{propertyName} Should be Greater than {ComparisionValue}")
                .MustAsync(async (id, token) =>
                {
                    var validation = await _allocationRepository.IsExist(id);
                    return !validation;
                });
        }
    }
}
