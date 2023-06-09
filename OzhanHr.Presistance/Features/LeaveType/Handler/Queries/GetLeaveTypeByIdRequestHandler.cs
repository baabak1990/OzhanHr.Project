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
    public class GetLeaveTypeByIdRequestHandler:IRequestHandler<GetLeaveTypeByIdRequest,LeaveTypeDTO>
    {
        private readonly IleaveTypeRepository _leaveTypeRepository;
        private readonly Mapper _mapper;

        public GetLeaveTypeByIdRequestHandler(IleaveTypeRepository leaveTypeRepository, Mapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<LeaveTypeDTO> Handle(GetLeaveTypeByIdRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.Get(request.Id);
            return _mapper.Map<LeaveTypeDTO>(leaveType);
        }
    }
}
