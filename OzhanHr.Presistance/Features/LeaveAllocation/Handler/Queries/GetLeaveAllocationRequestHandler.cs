using MediatR;
using OzhanHr.Application.DTOs.LeaveAllocation;
using OzhanHr.Application.Features.LeaveAllocation.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OzhanHr.Application.Contracts.Presistance.Repository;

namespace OzhanHr.Application.Features.LeaveAllocation.Handler.Queries
{

    public class GetLeaveAllocationRequestHandler : IRequestHandler<GetLeaveAllocationRequest, List<LeaveAllocationDTO>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly Mapper _mapper;

        public GetLeaveAllocationRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, Mapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        
        public async Task<List<LeaveAllocationDTO>> Handle(GetLeaveAllocationRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocations = await _leaveAllocationRepository.GetAll();
            return _mapper.Map<List<LeaveAllocationDTO>>(leaveAllocations);
        }
    }
}
