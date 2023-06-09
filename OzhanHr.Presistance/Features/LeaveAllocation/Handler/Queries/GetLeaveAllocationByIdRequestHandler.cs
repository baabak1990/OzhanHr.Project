using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OzhanHr.Application.Contracts.Presistance.Repository;
using OzhanHr.Application.DTOs.LeaveAllocation;
using OzhanHr.Application.Features.LeaveAllocation.Request.Queries;

namespace OzhanHr.Application.Features.LeaveAllocation.Handler.Queries
{
    public class GetLeaveAllocationByIdRequestHandler:IRequestHandler<GetLeaveAllocationByIdRequest,LeaveAllocationDTO>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly Mapper _mapper;

        public GetLeaveAllocationByIdRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, Mapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<LeaveAllocationDTO> Handle(GetLeaveAllocationByIdRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.Get(request.Id);
            return _mapper.Map<LeaveAllocationDTO>(leaveAllocation);
        }
    }
}
