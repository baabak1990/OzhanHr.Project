using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OzhanHr.Application.Contracts.Presistance.Repository;
using OzhanHr.Application.DTOs.LeaveType;
using OzhanHr.Application.Features.LeaveType.Request.Queries;

namespace OzhanHr.Application.Features.LeaveType.Handler.Queries
{
    public class GetLeaveTypeRequestHandler:IRequestHandler<GetLeaveTypeRequest,List<LeaveTypeDTO>>
    {
        private readonly IleaveTypeRepository _leaveTypeRepository;
        private readonly Mapper _mapper;

        public GetLeaveTypeRequestHandler(IleaveTypeRepository leaveTypeRepository, Mapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveTypeDTO>> Handle(GetLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
