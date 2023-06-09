using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OzhanHr.Application.DTOs.LeaveAllocation;

namespace OzhanHr.Application.Features.LeaveAllocation.Request.Queries
{
    public class GetLeaveAllocationByIdRequest:IRequest<LeaveAllocationDTO>
    {
        public int Id { get; set; }
    }
}
