using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OzhanHr.Application.DTOs.LeaveRequest;

namespace OzhanHr.Application.Features.LeaveRequest.Request.Commands
{
    public class CreateLeaveRequestCommand:IRequest<int>
    {
        public CreateLeaveRequestDTO Dto { get; set; }
    }
}
