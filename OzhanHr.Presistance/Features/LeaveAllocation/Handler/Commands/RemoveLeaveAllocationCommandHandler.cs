using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OzhanHr.Application.Contracts.Presistance.Repository;
using OzhanHr.Application.Features.LeaveAllocation.Request.Commands;

namespace OzhanHr.Application.Features.LeaveAllocation.Handler.Commands
{
    public class RemoveLeaveAllocationCommandHandler:IRequestHandler<RemoveLeaveAllocationCommand>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly Mapper _mapper;

        public RemoveLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, Mapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(RemoveLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.Get(request.AllocationDto.Id);
            if (leaveAllocation == null)
            {
                throw new Exception("Some Thing Happened ,Please Try Again !!!");
            }

            _mapper.Map(leaveAllocation, request.AllocationDto);
            await _leaveAllocationRepository.Delete(leaveAllocation);
            return Unit.Value;
        }
    }
}
