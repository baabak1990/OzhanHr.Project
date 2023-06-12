using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OzhanHr.Application.Contracts.Presistance.Repository;
using OzhanHr.Application.DTOs.LeaveType.Validation;
using OzhanHr.Application.Exceptions;
using OzhanHr.Application.Features.LeaveType.Request.Commands;

namespace OzhanHr.Application.Features.LeaveType.Handler.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {

        private readonly IleaveTypeRepository _leaveTypeRepository;
        private readonly Mapper _mapper;

        public UpdateLeaveTypeCommandHandler(IleaveTypeRepository leaveTypeRepository, Mapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validation = new LeaveTypeValidation();
            var validator = await validation.ValidateAsync(request.LeaveTypeDto);

            if (validator.IsValid == false)
            {
                throw new ValidationException(validator);
            }
            var leaveType = await _leaveTypeRepository.Get(request.LeaveTypeDto.Id);
            if (leaveType == null)
            {
                throw new NotFountException(nameof(leaveType), request.LeaveTypeDto.Id);
            }

            _mapper.Map(request.LeaveTypeDto, leaveType);
            await _leaveTypeRepository.Update(leaveType);
            return Unit.Value;

        }
    }
}
