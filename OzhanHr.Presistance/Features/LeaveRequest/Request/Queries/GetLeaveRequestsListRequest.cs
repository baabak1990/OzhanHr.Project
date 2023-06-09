using MediatR;
using OzhanHr.Application.DTOs.LeaveRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanHr.Application.Features.LeaveRequest.Request.Queries
{
    public class GetLeaveRequestsListRequest:IRequest<List<LeaveRequestListDTO>>
    {

    }
}
