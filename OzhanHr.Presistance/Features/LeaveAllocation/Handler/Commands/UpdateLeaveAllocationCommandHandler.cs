using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OzhanHr.Application.Contracts.Presistance.Repository;
using OzhanHr.Application.DTOs.LeaveAllocation.Validation;
using OzhanHr.Application.Exceptions;
using OzhanHr.Application.Features.LeaveAllocation.Request.Commands;

namespace OzhanHr.Application.Features.LeaveAllocation.Handler.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly Mapper _mapper;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, Mapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validation = new ChangeleaveAllocationValidation(_leaveAllocationRepository);
            var validatior = await validation.ValidateAsync(request.LeaveAllocationDto);
            if (validatior.IsValid == false)
            {
                //Take Care about the name space , this is our costumed exception !!
                throw new ValidationException(validatior);
            }
            var leaveAllocation = await _leaveAllocationRepository.Get(request.LeaveAllocationDto.Id);
            if (leaveAllocation == null)
            {
                throw new NotFountException(nameof(leaveAllocation), request.LeaveAllocationDto.Id);
            }

            _mapper.Map(request.LeaveAllocationDto, leaveAllocation);
            await _leaveAllocationRepository.Update(leaveAllocation);
            return Unit.Value;
        }
    }
}
