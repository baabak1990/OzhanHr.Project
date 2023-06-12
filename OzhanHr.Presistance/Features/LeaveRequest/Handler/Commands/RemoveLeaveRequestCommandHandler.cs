using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OzhanHr.Application.Contracts.Presistance.Repository;
using OzhanHr.Application.Features.LeaveRequest.Request.Commands;
using OzhanHr.Domain.Entities.Leave;

namespace OzhanHr.Application.Features.LeaveRequest.Handler.Commands
{
    public class RemoveLeaveRequestCommandHandler:IRequestHandler<RemoveLeaveRequestCommand>
    {
        private readonly IleaveRequestRepository _IleaveRequestRepository;
        private readonly IMapper _mapper;
        public RemoveLeaveRequestCommandHandler(IleaveRequestRepository IleaveRequestRepository, IMapper mapper)
        {
            _IleaveRequestRepository = IleaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(RemoveLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _IleaveRequestRepository.Get(request.LeaveRequestDto.Id);
            if (leaveRequest == null)
            {
                throw new Exception("Some thing Happened , Please Try Again !!!");

            }

            _mapper.Map(leaveRequest, request.LeaveRequestDto);
            await _IleaveRequestRepository.Delete(leaveRequest);
            return Unit.Value;
            
        }
    }
}
