using AutoMapper;
using MediatR;
using OzhanHr.Application.Contracts.Presistance.Repository;
using OzhanHr.Application.DTOs.LeaveRequest;
using OzhanHr.Application.Features.LeaveRequest.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanHr.Application.Features.LeaveRequest.Handler.Queries
{
    public class GetLeaveRequestsListHandler : IRequestHandler<GetLeaveRequestsListRequest, List<LeaveRequestListDTO>>
    {
        private readonly IleaveRequestRepository _IleaveRequestRepository;
        private readonly IMapper _mapper;
        public GetLeaveRequestsListHandler(IleaveRequestRepository IleaveRequestRepository, IMapper mapper)
        {
            _IleaveRequestRepository = IleaveRequestRepository;
            _mapper = mapper;
        }


        public async Task<List<LeaveRequestListDTO>> Handle(GetLeaveRequestsListRequest request, CancellationToken cancellationToken)
        {
            var leaveRequests=await _IleaveRequestRepository.GetAll();
            return _mapper.Map<List<LeaveRequestListDTO>>(leaveRequests);
        }
    }
}
