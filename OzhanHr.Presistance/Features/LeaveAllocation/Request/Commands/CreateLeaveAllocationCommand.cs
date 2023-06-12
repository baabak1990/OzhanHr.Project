using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OzhanHr.Application.DTOs.LeaveAllocation;

namespace OzhanHr.Application.Features.LeaveAllocation.Request.Commands
{
    public class CreateLeaveAllocationCommand:IRequest<int>
    {
        public CreateLeaveAllocationDTO Dto { get; set; }
    }
}
