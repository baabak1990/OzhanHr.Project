﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OzhanHr.Application.DTOs.LeaveType;

namespace OzhanHr.Application.Features.LeaveType.Request.Queries
{
    public class GetLeaveTypeRequest:IRequest<List<LeaveTypeDTO>>
    {

    }
}
