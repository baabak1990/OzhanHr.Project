using MediatR;
using OzhanHr.Application.DTOs.LeaveAllocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanHr.Application.Features.LeaveAllocation.Request.Queries
{
    public class GetLeaveAllocationRequest:IRequest<List<LeaveAllocationDTO>>
    {

    }
}
