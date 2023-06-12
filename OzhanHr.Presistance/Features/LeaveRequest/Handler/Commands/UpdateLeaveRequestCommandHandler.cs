using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OzhanHr.Application.Contracts.Presistance.Repository;
using OzhanHr.Application.Features.LeaveRequest.Request.Commands;

namespace OzhanHr.Application.Features.LeaveRequest.Handler.Commands
{
    public class UpdateLeaveRequestCommandHandler:IRequestHandler<UpdateLeaveRequestCommand,Unit>
    {
        private readonly IleaveRequestRepository _IleaveRequestRepository;
        private readonly IMapper _mapper;
        public UpdateLeaveRequestCommandHandler(IleaveRequestRepository IleaveRequestRepository, IMapper mapper)
        {
            _IleaveRequestRepository = IleaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _IleaveRequestRepository.Get(request.Id);
            if (leaveRequest == null)
            {
                throw new Exception("Some thing Happened Please Try Again !!!");
            }

            if (request.LeaveRequestStatuesDto != null)
            {
                _mapper.Map(leaveRequest, request.LeaveRequestStatuesDto);
                await _IleaveRequestRepository.Update(leaveRequest);
            }
            else if (request.ChangeApprovalStatuesDto != null)
            {
                _mapper.Map(leaveRequest, request.ChangeApprovalStatuesDto);
                await _IleaveRequestRepository.UpdateApprovedStatus(leaveRequest,request.ChangeApprovalStatuesDto.IsApproved);
            }

            return Unit.Value;
        }
    }
}
