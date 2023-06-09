﻿using OzhanHr.Domain.Entities.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanHr.Application.Contracts.Presistance.Repository
{
    public interface IleaveRequestRepository:IGenericRepository<LeaveRequest>
    {
        Task UpdateApprovedStatus(LeaveRequest leaveRequest, bool? IsApproved);
        Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestsWithDetails();
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
    }

}
