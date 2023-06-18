using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OzhanHr.Application.DTOs.LeaveRequest;

namespace OzhanHr.Application.Features.LeaveRequest.Request.Commands
{
    public class RemoveLeaveRequestCommand : IRequest<Unit>
    {
        public LeaveRequestDTO LeaveRequestDto { get; set; }
    }
}
