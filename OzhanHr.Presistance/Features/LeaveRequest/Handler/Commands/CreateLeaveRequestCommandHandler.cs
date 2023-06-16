using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OzhanHr.Application.Contracts.Infrastructure;
using OzhanHr.Application.Contracts.Presistance.Repository;
using OzhanHr.Application.DTOs.LeaveRequest.Validation;
using OzhanHr.Application.Exceptions;
using OzhanHr.Application.Features.LeaveRequest.Request.Commands;
using OzhanHr.Application.Model;

namespace OzhanHr.Application.Features.LeaveRequest.Handler.Commands
{
    public class CreateLeaveRequestCommandHandler:IRequestHandler<CreateLeaveRequestCommand,int>
    {
        private readonly IleaveRequestRepository _IleaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        public CreateLeaveRequestCommandHandler(IleaveRequestRepository IleaveRequestRepository, IMapper mapper, IEmailSender emailSender)
        {
            _IleaveRequestRepository = IleaveRequestRepository;
            _mapper = mapper;
            _emailSender = emailSender;
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

            var email = new Email
            {
                To = "Employee@org.com",
                Body = $"Your Leave Request For {request.Dto.StartDate:D} to {request.Dto.EndDate:D}" +
                       $"has been Submitted Successfully",
                Subject = "Leave Request Submitted"

            };
            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception e)
            {
                //"Log or Handle Error but dont throw exp"
            }

            return leavereqeust.Id;
        }
    }
}
