using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OzhanHr.Application.Contracts.Presistance.Repository;
using OzhanHr.Application.DTOs.LeaveAllocation.Validation;
using OzhanHr.Application.Features.LeaveAllocation.Request.Commands;

namespace OzhanHr.Application.Features.LeaveAllocation.Handler.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly Mapper _mapper;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, Mapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validation = new CreateLeaveAllocationValidation();
            var validatior = await validation.ValidateAsync(request.Dto);
            if (validatior.IsValid == false)
            {
                throw new Exception("Some Thing Happened ,Please Try Again !!!");
            }
            var leaveAllocation = _mapper.Map<Domain.Entities.Leave.LeaveAllocation>(request.Dto);
            if (leaveAllocation == null)
            {
                throw new Exception("Some Thing Happened ,Please Try Again !!!");
            }

            await _leaveAllocationRepository.Add(leaveAllocation);
            return leaveAllocation.Id;
        }
    }
}
