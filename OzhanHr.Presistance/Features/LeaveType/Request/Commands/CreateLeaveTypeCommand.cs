using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OzhanHr.Application.DTOs.LeaveType;

namespace OzhanHr.Application.Features.LeaveType.Request.Commands
{
    public class CreateLeaveTypeCommand:IRequest<int>
    {
        public CreateLeaveTypeDTO LeaveTypeDto { get; set; }
    }
}
