using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OzhanHr.Application.DTOs.LeaveType;

namespace OzhanHr.Application.Features.LeaveType.Request.Commands
{
    public class UpdateLeaveTypeCommand:IRequest<Unit>
    {
        public LeaveTypeDTO LeaveTypeDto { get; set; }
    }
}
