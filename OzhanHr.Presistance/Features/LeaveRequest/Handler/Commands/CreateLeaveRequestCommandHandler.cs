using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OzhanHr.Application.Contracts.Presistance.Repository;
using OzhanHr.Application.DTOs.LeaveRequest.Validation;
using OzhanHr.Application.Exceptions;
using OzhanHr.Application.Features.LeaveRequest.Request.Commands;

namespace OzhanHr.Application.Features.LeaveRequest.Handler.Commands
{
    public class CreateLeaveRequestCommandHandler:IRequestHandler<CreateLeaveRequestCommand,int>
    {
        private readonly IleaveRequestRepository _IleaveRequestRepository;
        private readonly IMapper _mapper;
        public CreateLeaveRequestCommandHandler(IleaveRequestRepository IleaveRequestRepository, IMapper mapper)
        {
            _IleaveRequestRepository = IleaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validation = new CreateleaveRequestValidation(_IleaveRequestRepository);
            var validatior = await validation.ValidateAsync(request.Dto);
            if (validatior.IsValid==false)
            {
                throw new ValidationException(validatior);
            }
            var leavereqeust = _mapper.Map<Domain.Entities.Leave.LeaveRequest>(request.Dto);
            if (leavereqeust == null)
            {
                throw new Exception("Some thing Happened , Please Try Again !!!");

            }

            await _IleaveRequestRepository.Add(leavereqeust);
            return leavereqeust.Id;
        }
    }
}
