using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OzhanHr.Application.Contracts.Presistance.Repository;
using OzhanHr.Application.Exceptions;
using OzhanHr.Application.Features.LeaveType.Request.Commands;
using OzhanHr.Domain.Entities.Leave;

namespace OzhanHr.Application.Features.LeaveType.Handler.Commands
{
    public class RemoveLeaveTypeCommandHandler:IRequestHandler<RemoveLeaveTypeCommand>
    {
        private readonly IleaveTypeRepository _leaveTypeRepository;
        private readonly Mapper _mapper;

        public RemoveLeaveTypeCommandHandler(IleaveTypeRepository leaveTypeRepository, Mapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(RemoveLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.Get(request.LeaveTypeDto.Id);
            if (leaveType == null)
            {
                throw new NotFountException(nameof(leaveType), request.LeaveTypeDto.Id);
            }

            _mapper.Map(leaveType, request.LeaveTypeDto);
            await _leaveTypeRepository.Delete(leaveType);
            return Unit.Value;
        }
    }
}
