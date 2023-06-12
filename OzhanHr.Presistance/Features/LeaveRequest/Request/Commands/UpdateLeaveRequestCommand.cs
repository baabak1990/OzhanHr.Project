using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OzhanHr.Application.DTOs.LeaveRequest;

namespace OzhanHr.Application.Features.LeaveRequest.Request.Commands
{
    public class UpdateLeaveRequestCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public LeaveRequestChangeApprovalStatuesDTO ChangeApprovalStatuesDto { get; set; }
        public ChangeLeaveRequestStatuesDTO LeaveRequestStatuesDto { get; set; }
    }
}
