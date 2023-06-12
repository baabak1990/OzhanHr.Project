using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OzhanHr.Application.Contracts.Presistance.Repository;
using OzhanHr.Application.Features.LeaveType.Request.Commands;

namespace OzhanHr.Application.Features.LeaveType.Handler.Commands
{
    public class CreateLeaveTypeCommandHandler:IRequestHandler<CreateLeaveTypeCommand,int>
    {
        private readonly IleaveTypeRepository _leaveTypeRepository;
        private readonly Mapper _mapper;

        public CreateLeaveTypeCommandHandler(IleaveTypeRepository leaveTypeRepository, Mapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leavetype =  _mapper.Map<Domain.Entities.Leave.LeaveType>(request.LeaveTypeDto);
            if (leavetype == null)
            {
                throw new Exception("Some Thing Happened please try again !!!");

            }

            await _leaveTypeRepository.Add(leavetype);
            return leavetype.Id;
        }
    }
}
